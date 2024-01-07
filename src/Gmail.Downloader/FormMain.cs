using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gmail.Downloader.Lib.Models;
using Gmail.Downloader.Lib.Services;
using Microsoft.Extensions.Logging.Abstractions;

namespace Gmail.Downloader
{
    public partial class FormMain : Form
    {
        private static readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions()
        {
            AllowTrailingCommas = true,
            PropertyNameCaseInsensitive = true,
        };

        private string _accessToken = "";

        private GoogleClientSecret _clientSecret;

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
                GoogleOAuthService googleOAuthService = new GoogleOAuthService(new NullLogger<GoogleOAuthService>());

                _accessToken = await googleOAuthService.DoOAuthAsync(
                    _clientSecret.ClientId,
                    _clientSecret.ClientSecret);
            }

            this.Activate();
            this.Focus();

            GoogleUserService googleUserService = new GoogleUserService(new NullLogger<GoogleUserService>());

            string userInfo = await googleUserService.GetUserInfoAsync(_accessToken);

            GoogleUserInfo googleUserInfo = JsonSerializer.Deserialize<GoogleUserInfo>(userInfo, _jsonSerializerOptions);

            GoogleGmailService googleGmailService = new GoogleGmailService(new NullLogger<GoogleGmailService>());

            string profileInfo = await googleGmailService.GetCurrentUserProfileAsync(_accessToken);

            GmailProfileInfo gmailProfileInfo = JsonSerializer.Deserialize<GmailProfileInfo>(profileInfo, _jsonSerializerOptions);

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

            GoogleGmailService googleGmailService = new GoogleGmailService(new NullLogger<GoogleGmailService>());

            string labelsResponse = await googleGmailService.GetCurrentUserLabelsAsync(_accessToken);

            GmailLabelList labelList = JsonSerializer.Deserialize<GmailLabelList>(labelsResponse, _jsonSerializerOptions);

            List<GmailLabel> labels = new List<GmailLabel>();

            object listLock = new object();

            await Parallel.ForEachAsync(labelList.Labels, async (label, cancellationToken) =>
            {
                labelsResponse = await googleGmailService.GetCurrentUserLabelAsync(_accessToken, label.Id);

                GmailLabel finalLabel = JsonSerializer.Deserialize<GmailLabel>(labelsResponse, _jsonSerializerOptions);

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

            GoogleGmailService googleGmailService = new GoogleGmailService(new NullLogger<GoogleGmailService>());

            List<GmailMessage> allMessages = new List<GmailMessage>();

            StringBuilder filterBuilder = new StringBuilder();
            filterBuilder.Append(txtFilterQuery.Text.Trim());

            filterBuilder.Append($" after:{dateTimePickerFrom.Value:yyyy/MM/dd}");
            filterBuilder.Append($" before:{dateTimePickerTo.Value:yyyy/MM/dd}");

            string filterQuery = filterBuilder.ToString();

            foreach (object labelItem in chkLabels.CheckedItems)
            {
                GmailLabel label = labelItem as GmailLabel;

                string messageResponse = await googleGmailService.GetCurrentUserMessagesAsync(_accessToken, filterQuery, new List<string>() { label.Id }, "");

                GmailMessageList messageList = JsonSerializer.Deserialize<GmailMessageList>(messageResponse, _jsonSerializerOptions);

                allMessages.AddRange(messageList.Messages);

                while (!string.IsNullOrWhiteSpace(messageList.NextPageToken))
                {
                    messageResponse = await googleGmailService.GetCurrentUserMessagesAsync(_accessToken, filterQuery, new List<string>() { label.Id }, messageList.NextPageToken);

                    messageList = JsonSerializer.Deserialize<GmailMessageList>(messageResponse, _jsonSerializerOptions);

                    allMessages.AddRange(messageList.Messages);
                }
            }

            List<GmailMessage> finalMessages = new List<GmailMessage>();

            object listLock = new object();

            await Parallel.ForEachAsync(allMessages, async (messageItem, cancellationToken) =>
            {
                string messageResponse = await googleGmailService.GetCurrentUserMessageAsync(_accessToken, messageItem.Id, Lib.Constants.GoogleGmailFormat.MessageFormat.Metadata);

                GmailMessage fullMessage = JsonSerializer.Deserialize<GmailMessage>(messageResponse, _jsonSerializerOptions);

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

            GoogleGmailService googleGmailService = new GoogleGmailService(new NullLogger<GoogleGmailService>());

            progressBar.Minimum = 0;
            progressBar.Maximum = chkMessages.CheckedItems.Count;
            progressBar.Value = 0;

            int counter = 0;
            foreach (object messageItem in chkMessages.CheckedItems)
            {
                string messageResponse = await googleGmailService.GetCurrentUserMessageAsync(_accessToken, (messageItem as GmailMessage).Id, Lib.Constants.GoogleGmailFormat.MessageFormat.Full);

                GmailMessage message = JsonSerializer.Deserialize<GmailMessage>(messageResponse, _jsonSerializerOptions);

                var attachments = message.Payload.Parts?.Where(p => !string.IsNullOrWhiteSpace(p.Body.AttachmentId))?.ToList() 
                    ?? Enumerable.Empty<GmailMessagePart>();

                foreach (GmailMessagePart attachment in attachments)
                {
                    string response = await googleGmailService.GetCurrentUserMessageAttachmentAsync(_accessToken, message.Id, attachment.Body.AttachmentId);

                    GmailMessagePartBody attachmentBody = JsonSerializer.Deserialize<GmailMessagePartBody>(response, _jsonSerializerOptions);

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
