using System.Collections.Generic;
using System.Linq;

namespace Gmail.Downloader.Lib.Models
{
    public class GmailMessage
    {
        /// <summary>
        /// The immutable ID of the message.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The ID of the thread the message belongs to. To add a message or draft to a thread, the following criteria must be met:
        /// 1. The requested threadId must be specified on the Message or Draft.Message you supply with your request.
        /// 2. The References and In-Reply-To headers must be set in compliance with the RFC 2822 standard.
        /// 3. The Subject headers must match.
        /// </summary>
        public string ThreadId { get; set; }

        /// <summary>
        /// List of IDs of labels applied to this message.
        /// </summary>
        public List<string> LabelIds { get; set; }

        /// <summary>
        /// A short part of the message text.
        /// </summary>
        public string Snippet { get; set; }

        /// <summary>
        /// The ID of the last history record that modified this message.
        /// </summary>
        public string HistoryId { get; set; }

        /// <summary>
        /// The internal message creation timestamp (epoch ms), which determines ordering in the inbox. 
        /// For normal SMTP-received email, this represents the time the message was originally accepted by Google, 
        /// which is more reliable than the Date header. 
        /// However, for API-migrated mail, it can be configured by client to be based on the Date header.
        /// </summary>
        public string InternalDate { get; set; }

        /// <summary>
        /// The parsed email structure in the message parts.
        /// </summary>
        public GmailMessagePart Payload { get; set; }

        /// <summary>
        /// Estimated size in bytes of the message.
        /// </summary>
        public int SizeEstimate { get; set; }

        /// <summary>
        /// The entire email message in an RFC 2822 formatted and base64url encoded string. Returned in messages.get and drafts.get responses when the format=RAW parameter is supplied.
        /// A base64-encoded string.
        /// </summary>
        public string Raw { get; set; }

        private string MailDate()
        {
            return Payload?.Headers?.FirstOrDefault(h => h.Name == "Date")?.Value ?? "-";
        }

        private string From()
        {
            return Payload?.Headers?.FirstOrDefault(h => h.Name == "From")?.Value ?? "-";
        }

        private string Subject()
        {
            return Payload?.Headers?.FirstOrDefault(h => h.Name == "Subject")?.Value ?? "-";
        }

        public override string ToString()
        {
            return $"{MailDate()} {From()} {Subject()}";
        }
    }

    public class GmailMessagePart
    {
        /// <summary>
        /// The immutable ID of the message part.
        /// </summary>
        public string PartId { get; set; }

        /// <summary>
        /// The MIME type of the message part.
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// The filename of the attachment. Only present if this message part represents an attachment.
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// List of headers on this message part. For the top-level message part, representing the entire message payload, it will contain the standard RFC 2822 email headers such as To, From, and Subject.
        /// </summary>
        public List<GmailMessageHeader> Headers { get; set; }

        /// <summary>
        /// The message part body for this part, which may be empty for container MIME message parts.
        /// </summary>
        public GmailMessagePartBody Body { get; set; }

        /// <summary>
        /// The child MIME message parts of this part. 
        /// This only applies to container MIME message parts, for example multipart/*. 
        /// For non- container MIME message part types, such as text/plain, this field is empty. 
        /// For more information, see RFC 1521.
        /// </summary>
        public List<GmailMessagePart> Parts { get; set; } 
    }

    public class GmailMessageHeader
    {
        /// <summary>
        /// The name of the header before the : separator. For example, To.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The value of the header after the : separator. For example, someuser@example.com.
        /// </summary>
        public string Value { get; set; }
    }

    public class GmailMessagePartBody
    {
        /// <summary>
        /// When present, contains the ID of an external attachment that can be retrieved in a separate messages.attachments.get request. 
        /// When not present, the entire content of the message part body is contained in the data field.
        /// </summary>
        public string AttachmentId { get; set; }

        /// <summary>
        /// Number of bytes for the message part data (encoding notwithstanding).
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// The body data of a MIME message part as a base64url encoded string. 
        /// May be empty for MIME container types that have no message body or when the body data is sent as a separate attachment. 
        /// An attachment ID is present if the body data is contained in a separate attachment.
        /// A base64-encoded string.
        /// </summary>
        public string Data { get; set; }
    }
}
