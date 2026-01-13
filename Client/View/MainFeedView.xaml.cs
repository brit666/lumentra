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

        private void VideoCard_Clicked(FeedVideoModel video)
        {
            CourseTitle.Text = video.VideoTitle;
            CourseAuthor.Text = video.VideoAuthor;
            CourseViews.Text = video.VideoViews;
            CourseRatings.Text = video.VideoRatings;
            CourseDescription.Text = video.VideoDescription;
            CoursePrice.Text = video.VideoPrice;
            CourseDuration.Text = video.VideoDuration;

            CourseSeparator1.Visibility = Visibility.Visible;
            CourseSeparator2.Visibility = Visibility.Visible;
            BuyNow_Button.Visibility = Visibility.Visible;
            CourseInfo.Visibility = Visibility.Visible;

            CourseThumbnail.ImageSource = new BitmapImage(new Uri(video.VideoThumbnailUrl, UriKind.RelativeOrAbsolute));
        }

        private void VideoCards_Loaded(object sender, RoutedEventArgs e)
        {
            if(sender is VideoCards vc)
            {
                vc.VideoClicked += VideoCard_Clicked;
            }
        }

        private void BuyNow_Button_Click(object sender, RoutedEventArgs e)
        {
            CourseInfo.Visibility = Visibility.Visible;
        }
    }
}
