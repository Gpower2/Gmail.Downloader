using System.Collections.Generic;

namespace Gmail.Downloader.Lib.Models
{
    public class GmailMessageList
    {
        /// <summary>
        /// List of messages. Note that each message resource contains only an id and a threadId. 
        /// Additional message details can be fetched using the messages.get method.
        /// </summary>
        public List<GmailMessage> Messages { get; set; }

        /// <summary>
        /// Token to retrieve the next page of results in the list.
        /// </summary>
        public string NextPageToken { get; set; }

        /// <summary>
        /// Estimated total number of results.
        /// </summary>
        public int ResultSizeEstimate { get; set; }
    }
}
