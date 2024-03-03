using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gmail.Downloader.Lib.Extensions;
using Gmail.Downloader.Lib.Models;
using Gmail.Downloader.Lib.Repositories;
using Gmail.Downloader.Lib.Services;
using Gmail.Downloader.Lib.Services.Abstractions;
using Microsoft.Extensions.Logging.Abstractions;

namespace Gmail.Downloader
{
    public partial class FormMain : Form
    {
        private string _accessToken = "";

        private GoogleClientSecret _clientSecret;

        private readonly GoogleOAuthRepository _googleOAuthRepository = new GoogleOAuthRepository(
            new NullLogger<GoogleOAuthRepository>());

        private readonly IGoogleUserService _googleUserService = new GoogleUserService(
            new GoogleUserRepository(new NullLogger<GoogleUserRepository>()), 
            new NullLogger<GoogleUserService>());

        private readonly IGoogleGmailService _googleGmailService = new GoogleGmailService(
            new GoogleGmailRepository(new NullLogger<GoogleGmailRepository>()),
            new NullLogger<GoogleGmailService>()
        );

        public FormMain()
        {
            InitializeComponent();

            // Set form title 
            Text = string.Format("Gmail Downloader v{0} -- By Gpower2", Assembly.GetExecutingAssembly().GetName().Version);

            dateTimePickerFrom.Value = DateTime.Now.AddMonths(-1);

            // Read the Google Client Secrets

            string secretsFilename = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "client_secret.json");
            if (!File.Exists(secretsFilename))
            {
                MessageBox.Show("No secrets found!", "No secrets found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GoogleClientSecretContent secretsContent = JsonSerializer.Deserialize<GoogleClientSecretContent>(File.ReadAllText(secretsFilename));
            _clientSecret = secretsContent.Installed;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_accessToken))
            {
                _accessToken = await _googleOAuthRepository.DoOAuthAsync(
                    _clientSecret.ClientId,
                    _clientSecret.ClientSecret);
            }

            this.Activate();
            this.Focus();

            GoogleUserInfo googleUserInfo = await _googleUserService.GetUserInfoAsync(_accessToken);

            GmailProfileInfo gmailProfileInfo = await _googleGmailService.GetCurrentUserProfileAsync(_accessToken);

            StringBuilder infoBuilder = new StringBuilder();

            infoBuilder.AppendLine($"Sub: {googleUserInfo.Sub}");
            infoBuilder.AppendLine($"Name: {googleUserInfo.Name}");
            infoBuilder.AppendLine($"Locale: {googleUserInfo.Locale}");

            infoBuilder.AppendLine($"Email: {gmailProfileInfo.EmailAddress}");
            infoBuilder.AppendLine($"Total Messages: {gmailProfileInfo.MessagesTotal}");

            txtUserInfo.Text = infoBuilder.ToString();
        }

        private async void btnGetLabels_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_accessToken))
            {
                MessageBox.Show("Please login first!", "Please Login!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GmailLabelList labelList = await _googleGmailService.GetCurrentUserLabelsAsync(_accessToken);

            List<GmailLabel> labels = new List<GmailLabel>();

            object listLock = new object();

            await Parallel.ForEachAsync(labelList.Labels, async (label, cancellationToken) =>
            {
                GmailLabel finalLabel = await _googleGmailService.GetCurrentUserLabelAsync(_accessToken, label.Id);

                lock (listLock)
                {
                    labels.Add(finalLabel);
                }
            });

            chkLabels.Items.Clear();

            chkLabels.Items.AddRange(labels.OrderBy(l => l.Name).ToArray());

            grpLabels.Text = $"Labels ({labels.Count})";
        }

        private async void btnGetMessages_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_accessToken))
            {
                MessageBox.Show("Please login first!", "Please Login!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chkLabels.Items.Count == 0)
            {
                MessageBox.Show("Please get Labels first!", "Please get Labels!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chkLabels.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select Labels first!", "Please select Labels!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dateTimePickerFrom.Value > DateTime.Now)
            {
                MessageBox.Show("Please select valid From date!", "Please select valid From date!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dateTimePickerFrom.Value > dateTimePickerTo.Value)
            {
                MessageBox.Show("Please select valid From/To dates!", "Please select valid From/To dates!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<GmailMessage> allMessages = new List<GmailMessage>();

            StringBuilder filterBuilder = new StringBuilder();
            filterBuilder.Append(txtFilterQuery.Text.Trim());

            filterBuilder.Append($" after:{dateTimePickerFrom.Value:yyyy/MM/dd}");
            filterBuilder.Append($" before:{dateTimePickerTo.Value:yyyy/MM/dd}");

            string filterQuery = filterBuilder.ToString();

            foreach (object labelItem in chkLabels.CheckedItems)
            {
                GmailLabel label = labelItem as GmailLabel;

                GmailMessageList messageList = await _googleGmailService.GetCurrentUserMessagesAsync(
                    _accessToken, filterQuery, new List<string>() { label.Id }, "");

                allMessages.AddRange(messageList.Messages);

                while (!string.IsNullOrWhiteSpace(messageList.NextPageToken))
                {
                    messageList = await _googleGmailService.GetCurrentUserMessagesAsync(
                        _accessToken, filterQuery, new List<string>() { label.Id }, messageList.NextPageToken);

                    allMessages.AddRange(messageList.Messages);
                }
            }

            List<GmailMessage> finalMessages = new List<GmailMessage>();

            object listLock = new object();

            await Parallel.ForEachAsync(allMessages, async (messageItem, cancellationToken) =>
            {
                GmailMessage fullMessage = await _googleGmailService.GetCurrentUserMessageAsync(
                    _accessToken, messageItem.Id, Lib.Constants.GoogleGmailFormat.MessageFormat.Metadata);

                lock (listLock)
                {
                    finalMessages.Add(fullMessage);
                }
            });

            chkMessages.Items.Clear();

            chkMessages.Items.AddRange(finalMessages.OrderByDescending(m => m.InternalDate).ToArray());

            grpMessages.Text = $"Messages ({finalMessages.Count})";
        }

        private async void btnGetAttachments_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_accessToken))
            {
                MessageBox.Show("Please login first!", "Please Login!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chkMessages.Items.Count == 0)
            {
                MessageBox.Show("Please get Messages first!", "Please get Messages!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chkMessages.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select Messages!", "Please select Messages!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "-";
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            string path = Path.GetDirectoryName(sfd.FileName);

            progressBar.Minimum = 0;
            progressBar.Maximum = chkMessages.CheckedItems.Count;
            progressBar.Value = 0;

            int counter = 0;
            foreach (object messageItem in chkMessages.CheckedItems)
            {
                GmailMessage message = await _googleGmailService.GetCurrentUserMessageAsync(
                    _accessToken, (messageItem as GmailMessage).Id, Lib.Constants.GoogleGmailFormat.MessageFormat.Full);

                var attachments = message.Payload.Parts?.Where(p => !string.IsNullOrWhiteSpace(p.Body.AttachmentId))?.ToList() 
                    ?? Enumerable.Empty<GmailMessagePart>();

                foreach (GmailMessagePart attachment in attachments)
                {
                    GmailMessagePartBody attachmentBody = await _googleGmailService.GetCurrentUserMessageAttachmentAsync(
                        _accessToken, message.Id, attachment.Body.AttachmentId);

                    string datePrefix = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(message.InternalDate)).DateTime.ToString("yyyy-MM-dd_HH-mm_");

                    string finalFilename = Path.Combine(path, $"{datePrefix}{attachment.Filename.RemoveInvalidFileCharacters()}");

                    UpdateStatusBar($"Downloading: '{attachment.Filename}'");

                    byte[] fileData = Base64Service.DecodeFromBase64Url(attachmentBody.Data);

                    await File.WriteAllBytesAsync(finalFilename, fileData);
                }

                counter++;
                UpdateProgressBar(counter);
            }

            MessageBox.Show($"All attachments ({counter}) were downloaded!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateProgressBar(int value)
        {
            this.Invoke(() => { this.progressBar.Value = value; });
        }

        private void UpdateStatusBar(string message)
        {
            this.Invoke(() => { this.txtStatus.Text = message; });
        }

        private void btnCheckAllMessages_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chkMessages.Items.Count; i++)
            {
                chkMessages.SetItemChecked(i, true);
            }
        }

        private void btnUncheckAllMessages_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chkMessages.Items.Count; i++)
            {
                chkMessages.SetItemChecked(i, false);
            }
        }
    }
}
