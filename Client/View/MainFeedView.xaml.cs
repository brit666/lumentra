using lumentra.Model;
using lumentra.View.UserControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace lumentra.View
{
    /// <summary>
    /// Interaction logic for MainFeedView.xaml
    /// </summary>
    public partial class MainFeedView : Window
    {
        public MainFeedView()
        {
            InitializeComponent();
            FeedVideoFetcher();
        }

        private void FeedVideoFetcher()
        {
            string jsonString = System.IO.File.ReadAllText("D:\\C# Projects\\lumentra\\Client\\FeedVideos.json");
            var videos = JsonSerializer.Deserialize<List<FeedVideoModel>>(jsonString);

            VideoFeed.ItemsSource = videos;

            
        }

        private void VideoCard_Clicked(object sender, FeedVideoModel video)
        {
            // Example: populate some TextBoxes on the side
            CourseTitle.Text = video.VideoTitle;
            CourseAuthor.Text = video.VideoAuthor;
            CourseViews.Text = video.VideoViews;
            CourseRatings.Text = video.VideoRatings;


            // Optional: show the thumbnail
            CourseThumbnail.ImageSource = new BitmapImage(new Uri(video.VideoThumbnailUrl, UriKind.RelativeOrAbsolute));
        }
    }
}
