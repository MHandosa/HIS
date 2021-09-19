using System;

namespace Endoscopy.Models
{
    internal class MediaModel
    {
        public enum MediaType { Image, Video }

        public string Path { get; set; }
        public MediaType Type { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
