using lumentra.Model;
using lumentra.View.UserControl;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for ExploreView.xaml
    /// </summary>
    public partial class ExploreView : Window
    {
        public ExploreView()
        {
            InitializeComponent();
            FeedVideoFetcher();
        }

        public string SearchText { get; set; }
        public ExploreView(string _searchText)
        {
            SearchText = _searchText;
            InitializeComponent();
            PerformSearch(SearchText);
        }

        public void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var text = SearchBox.Text.Trim();
                PerformSearch(text);
            }
        }

        void PerformSearch(string text)
        {
            NoResultsText.Visibility = Visibility.Collapsed;
            SearchQueryText.Text = text;

            string jsonString = File.ReadAllText(App.FeedJsonPath);

            var videos = JsonSerializer.Deserialize<List<FeedVideoModel>>(jsonString);

            if (string.IsNullOrWhiteSpace(text))
            {
                VideoFeed.ItemsSource = videos;
                SearchQueryText.Text = "Explore";
                return;
            }

            var filtered = videos
                .Where(v => v.VideoTitle.Contains(text, StringComparison.OrdinalIgnoreCase)
                         || v.VideoAuthor.Contains(text, StringComparison.OrdinalIgnoreCase))
                .ToList();

            VideoFeed.ItemsSource = filtered;

            if(filtered.Count == 0)
            {
                NoResultsText.Visibility = Visibility.Visible;
            }
        }


        private void FeedVideoFetcher()
        {
            string jsonString = File.ReadAllText(App.FeedJsonPath);

            var videos = JsonSerializer.Deserialize<List<FeedVideoModel>>(jsonString);

            var SearchVideos = videos.Where(
                video => video.IsVideoPopular == true
            ).ToList();

            VideoFeed.ItemsSource = SearchVideos;


        }

        private void VideoCards_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is VideoCards vc)
            {
                vc.VideoClicked += VideoCard_Clicked;
            }
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

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new MainFeedView();
            this.Top = window.Top;
            window.Show();
            this.Close();
        }

        private void ExploreButton_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void NotificationButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new NotificationView();
            window.Owner = this;
            window.ShowDialog();

        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new ProfileView();
            window.Owner = this;
            window.ShowDialog();
        }

        private void CollectionButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new CollectionView();
            window.Owner = this;
            window.ShowDialog();
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

        private void ProgrammingButton_Click(object sender, RoutedEventArgs e)
        {
            string jsonString = File.ReadAllText(App.FeedJsonPath);
            var videos = JsonSerializer.Deserialize<List<FeedVideoModel>>(jsonString);
            var SearchVideos = videos.Where(
                video => video.VideoCategory == "Programming"
            ).ToList();
            VideoFeed.ItemsSource = SearchVideos;

            SearchQueryText.Text = "Programming & Tech";
        }

        private void EducationButton_Click(object sender, RoutedEventArgs e)
        {
            string jsonString = File.ReadAllText(App.FeedJsonPath);
            var videos = JsonSerializer.Deserialize<List<FeedVideoModel>>(jsonString);
            var SearchVideos = videos.Where(
                video => video.VideoCategory == "Education"
            ).ToList();
            VideoFeed.ItemsSource = SearchVideos;

            SearchQueryText.Text = "Education";
        }

        private void PhotographyButton_Click(object sender, RoutedEventArgs e)
        {
            string jsonString = File.ReadAllText(App.FeedJsonPath);
            var videos = JsonSerializer.Deserialize<List<FeedVideoModel>>(jsonString);
            var SearchVideos = videos.Where(
                video => video.VideoCategory == "Photography"
            ).ToList();
            VideoFeed.ItemsSource = SearchVideos;

            SearchQueryText.Text = "Photography & Videography";
        }

        private void MusicButton_Click(object sender, RoutedEventArgs e)
        {
            string jsonString = File.ReadAllText(App.FeedJsonPath);
            var videos = JsonSerializer.Deserialize<List<FeedVideoModel>>(jsonString);
            var SearchVideos = videos.Where(
                video => video.VideoCategory == "Music"
            ).ToList();
            VideoFeed.ItemsSource = SearchVideos;

            SearchQueryText.Text = "Music";
        }

        private void ScienceButton_Click(object sender, RoutedEventArgs e)
        {
            string jsonString = File.ReadAllText(App.FeedJsonPath);
            var videos = JsonSerializer.Deserialize<List<FeedVideoModel>>(jsonString);
            var SearchVideos = videos.Where(
                video => video.VideoCategory == "Science"
            ).ToList();
            VideoFeed.ItemsSource = SearchVideos;

            SearchQueryText.Text = "Science & Engineering";
        }

        private void ArtButton_Click(object sender, RoutedEventArgs e)
        {
            string jsonString = File.ReadAllText(App.FeedJsonPath);
            var videos = JsonSerializer.Deserialize<List<FeedVideoModel>>(jsonString);
            var SearchVideos = videos.Where(
                video => video.VideoCategory == "Art"
            ).ToList();
            VideoFeed.ItemsSource = SearchVideos;

            SearchQueryText.Text = "Art & Design";
        }

        private void ProductivityButton_Click(object sender, RoutedEventArgs e)
        {
            string jsonString = File.ReadAllText(App.FeedJsonPath);
            var videos = JsonSerializer.Deserialize<List<FeedVideoModel>>(jsonString);
            var SearchVideos = videos.Where(
                video => video.VideoCategory == "Productivity"
            ).ToList();
            VideoFeed.ItemsSource = SearchVideos;

            SearchQueryText.Text = "Productivity & Career Advice";
        }

        private void BusinessButton_Click(object sender, RoutedEventArgs e)
        {
            string jsonString = File.ReadAllText(App.FeedJsonPath);
            var videos = JsonSerializer.Deserialize<List<FeedVideoModel>>(jsonString);
            var SearchVideos = videos.Where(
                video => video.VideoCategory == "Business"
            ).ToList();
            VideoFeed.ItemsSource = SearchVideos;

            SearchQueryText.Text = "Business & Finance";
        }

        private void CookingButton_Click(object sender, RoutedEventArgs e)
        {
            string jsonString = File.ReadAllText(App.FeedJsonPath);
            var videos = JsonSerializer.Deserialize<List<FeedVideoModel>>(jsonString);
            var SearchVideos = videos.Where(
                video => video.VideoCategory == "Cooking"
            ).ToList();
            VideoFeed.ItemsSource = SearchVideos;

            SearchQueryText.Text = "Cooking & Food";
        }

        private void SportsButton_Click(object sender, RoutedEventArgs e)
        {
            string jsonString = File.ReadAllText(App.FeedJsonPath);
            var videos = JsonSerializer.Deserialize<List<FeedVideoModel>>(jsonString);
            var SearchVideos = videos.Where(
                video => video.VideoCategory == "Fitness"
            ).ToList();
            VideoFeed.ItemsSource = SearchVideos;

            SearchQueryText.Text = "Fitness & Fitness";
        }

        private void BuyNow_Button_Click(object sender, RoutedEventArgs e)
        {
            CourseInfo.Visibility = Visibility.Visible;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
