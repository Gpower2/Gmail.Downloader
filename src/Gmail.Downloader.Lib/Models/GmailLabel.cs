using System.Text.Json.Serialization;

namespace Gmail.Downloader.Lib.Models
{
    public enum MessageListVisibility
    {
        /// <summary>
        /// Show the label in the message list.
        /// </summary>
        show,
        /// <summary>
        /// Do not show the label in the message list.
        /// </summary>
        hide,
    }

    public enum LabelListVisibility
    {
        /// <summary>
        /// Show the label in the label list.
        /// </summary>
        labelShow,
        /// <summary>
        /// Show the label if there are any unread messages with that label.
        /// </summary>
        labelShowIfUnread,
        /// <summary>
        /// Do not show the label in the label list.
        /// </summary>
        labelHide,
    }

    public enum LabelType
    {
        /// <summary>
        /// Labels created by Gmail.
        /// </summary>
        system,
        /// <summary>
        /// Custom labels created by the user or application.
        /// </summary>
        user,
    }

    public class GmailLabel
    {
        /// <summary>
        /// The immutable ID of the label.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The display name of the label.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The visibility of messages with this label in the message list in the Gmail web interface.
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MessageListVisibility MessageListVisibility { get; set; }

        /// <summary>
        /// The visibility of the label in the label list in the Gmail web interface.
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LabelListVisibility LabelListVisibility { get; set; }

        /// <summary>
        /// The owner type for the label. 
        /// User labels are created by the user and can be modified and deleted by the user and can be applied to any message or thread. 
        /// System labels are internally created and cannot be added, modified, or deleted. 
        /// System labels may be able to be applied to or removed from messages and threads under some circumstances but this is not guaranteed. 
        /// For example, users can apply and remove the INBOX and UNREAD labels from messages and threads, 
        /// but cannot apply or remove the DRAFTS or SENT labels from messages or threads.
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]        
        public LabelType Type { get; set; }

        /// <summary>
        /// The total number of messages with the label.
        /// </summary>
        public int MessagesTotal { get; set; }

        /// <summary>
        /// The number of unread messages with the label.
        /// </summary>
        public int MessagesUnread { get; set; }

        /// <summary>
        /// The total number of threads with the label.
        /// </summary>
        public int ThreadsTotal { get; set; }

        /// <summary>
        /// The number of unread threads with the label.
        /// </summary>
        public int ThreadsUnread { get; set; }

        /// <summary>
        /// The color to assign to the label. Color is only available for labels that have their type set to user.
        /// </summary>
        public LabelColor Color { get; set; }

        public override string ToString()
        {
            return $"{Name} ({MessagesUnread}/{MessagesTotal})";
        }
    }

    public class LabelColor
    {
        /// <summary>
        /// The text color of the label, represented as hex string. This field is required in order to set the color of a label.
        /// </summary>
        public string TextColor { get; set; }

        /// <summary>
        /// The background color represented as hex string #RRGGBB (ex #000000). This field is required in order to set the color of a label. 
        /// </summary>
        public string BackgroundColor { get; set; }
    }
}
