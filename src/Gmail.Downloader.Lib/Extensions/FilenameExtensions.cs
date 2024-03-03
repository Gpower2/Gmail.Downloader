using System;
using System.IO;
using System.Linq;

namespace Gmail.Downloader.Lib.Extensions
{
    public static class FilenameExtensions
    {
        private static readonly char[] _invalidFilenameChars = Path.GetInvalidFileNameChars();

        public static string RemoveInvalidFileCharacters(this string filename)
        {
            // Replace illegal filename characters with '_'
            if (filename.AsEnumerable().Any(c => _invalidFilenameChars.Contains(c)))
            {
                filename = string.Join("_", filename.Split(_invalidFilenameChars));
            }

            return filename;
        }
    }
}
