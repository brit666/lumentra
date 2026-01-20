using lumentra.Model;
using lumentra.View.UserControl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
            string jsonString = File.ReadAllText(App.FeedJsonPath);
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

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new MainFeedView();
            this.Top = window.Top;
            window.Show();
            this.Close();
        }

        private void ExploreButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new ExploreView();
            this.Top = window.Top;
            window.Show();
            this.Close();
        }

        private void NotificationButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new NotificationView();
            window.Owner = this;
            window.ShowDialog();
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CollectionButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new LoginView();
            this.Top = window.Top;
            window.Show();
            this.Close();
        }

        private void SubscribeButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new ExploreView();
            this.Top = window.Top;
            window.Show();
            this.Close();
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string query = SearchBox.Text;
                Window window = new ExploreView(query);
                this.Top = window.Top;
                window.Show();
                this.Close();
            }
        }
    }
}
