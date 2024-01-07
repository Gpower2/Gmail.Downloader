namespace Gmail.Downloader.Lib.Models
{
    public class GmailProfileInfo
    {
        /// <summary>
        /// The user's email address.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// The total number of messages in the mailbox.
        /// </summary>
        public int MessagesTotal { get; set; }

        /// <summary>
        /// The total number of threads in the mailbox.
        /// </summary>
        public int ThreadsTotal { get; set; }

        /// <summary>
        /// The ID of the mailbox's current history record.
        /// </summary>
        public string HistoryId { get; set; }
    }
}
