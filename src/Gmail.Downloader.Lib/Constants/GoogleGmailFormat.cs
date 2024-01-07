namespace Gmail.Downloader.Lib.Constants
{
    public static class GoogleGmailFormat
    {
        public enum MessageFormat
        {
            /// <summary>
            /// Returns only email message ID and labels; does not return the email headers, body, or payload.
            /// </summary>
            Minimal,
            
            /// <summary>
            /// Returns the full email message data with body content parsed in the payload field; the raw field is not used. 
            /// Format cannot be used when accessing the api using the gmail.metadata scope.
            /// </summary>
            Full,
            
            /// <summary>
            /// Returns the full email message data with body content in the raw field as a base64url encoded string; the payload field is not used. 
            /// Format cannot be used when accessing the api using the gmail.metadata scope.
            /// </summary>
            Raw,
            
            /// <summary>
            /// Returns only email message ID, labels, and email headers.
            /// </summary>
            Metadata,
        }

        /// <summary>
        /// Returns only email message ID and labels; does not return the email headers, body, or payload.
        /// </summary>
        public static string Minimal = "minimal";

        /// <summary>
        /// Returns the full email message data with body content parsed in the payload field; the raw field is not used. 
        /// Format cannot be used when accessing the api using the gmail.metadata scope.
        /// </summary>
        public static string Full = "full";

        /// <summary>
        /// Returns the full email message data with body content in the raw field as a base64url encoded string; the payload field is not used. 
        /// Format cannot be used when accessing the api using the gmail.metadata scope.
        /// </summary>
        public static string Raw = "raw";

        /// <summary>
        /// Returns only email message ID, labels, and email headers.
        /// </summary>
        public static string Metadata = "metadata";

        public static string GetGoogleFormat(this MessageFormat format)
        {
            switch (format)
            {
                case MessageFormat.Minimal:
                    return Minimal;
                case MessageFormat.Full:
                    return Full;
                case MessageFormat.Raw:
                    return Raw;
                case MessageFormat.Metadata:
                    return Metadata;
                default:
                    return null;
            }
        }
    }
}
