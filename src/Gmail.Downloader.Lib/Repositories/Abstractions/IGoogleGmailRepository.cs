using System.Collections.Generic;
using System.Threading.Tasks;
using Gmail.Downloader.Lib.Constants;

namespace Gmail.Downloader.Lib.Repositories.Abstractions
{
    public interface IGoogleGmailRepository
    {
        Task<string> GetCurrentUserLabelAsync(string accessToken, string labelId);
        Task<string> GetCurrentUserLabelsAsync(string accessToken);
        Task<string> GetCurrentUserMessageAsync(string accessToken, string messageId, GoogleGmailFormat.MessageFormat messageFormat);
        Task<string> GetCurrentUserMessageAttachmentAsync(string accessToken, string messageId, string attachmentId);
        Task<string> GetCurrentUserMessagesAsync(string accessToken, string query, List<string> labels, string pageToken);
        Task<string> GetCurrentUserProfileAsync(string accessToken);
    }
}