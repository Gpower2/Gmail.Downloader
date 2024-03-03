using System.Collections.Generic;
using System.Threading.Tasks;
using Gmail.Downloader.Lib.Constants;
using Gmail.Downloader.Lib.Models;

namespace Gmail.Downloader.Lib.Services.Abstractions
{
    public interface IGoogleGmailService
    {
        Task<GmailLabel> GetCurrentUserLabelAsync(string accessToken, string labelId);
        Task<GmailLabelList> GetCurrentUserLabelsAsync(string accessToken);
        Task<GmailMessage> GetCurrentUserMessageAsync(string accessToken, string messageId, GoogleGmailFormat.MessageFormat messageFormat);
        Task<GmailMessagePartBody> GetCurrentUserMessageAttachmentAsync(string accessToken, string messageId, string attachmentId);
        Task<GmailMessageList> GetCurrentUserMessagesAsync(string accessToken, string query, List<string> labels, string pageToken);
        Task<GmailProfileInfo> GetCurrentUserProfileAsync(string accessToken);
    }
}