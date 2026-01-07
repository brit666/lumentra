using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lumentra.Model
{
    class Video
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public string Url { get; set; }
        public DateTime UploadDate { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
