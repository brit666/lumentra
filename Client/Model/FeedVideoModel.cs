using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lumentra.Model
{
    public class FeedVideoModel
    {
        public string VideoTitle { get; set; }
        public string VideoThumbnailUrl {get; set; }
        public string VideoAuthor { get; set; }
        public string VideoRatings { get; set; }
        public string VideoViews { get; set; }

        public Uri ThumbnailUri => new Uri(VideoThumbnailUrl, UriKind.RelativeOrAbsolute);
    }
}
