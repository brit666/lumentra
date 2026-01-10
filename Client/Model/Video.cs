using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lumentra.Model
{
    class Video
    {
        public string VideoId { get; set; }
        public string VideoTitle { get; set; }
        public string VideoDescription { get; set; }
        public TimeSpan VideoDuration { get; set; }
        public string VideoUrl { get; set; }
        public DateTime UploadDate { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
