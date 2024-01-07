using System.Collections.Generic;

namespace Gmail.Downloader.Lib.Models
{
    public class GmailLabelList
    {
        /// <summary>
        /// List of labels. Note that each label resource only contains an id, name, messageListVisibility, labelListVisibility, and type. 
        /// The labels.get method can fetch additional label details.
        /// </summary>
        public List<GmailLabel> Labels { get; set; }
    }
}
