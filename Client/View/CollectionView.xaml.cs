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
    /// Interaction logic for CollectionView.xaml
    /// </summary>
    public partial class CollectionView : Window
    {
        public CollectionView()
        {
            InitializeComponent();
            FeedVideoFetcher();
        }

        private void FeedVideoFetcher()
        {
            string jsonString = File.ReadAllText(App.FeedJsonPath);

            var videos = JsonSerializer.Deserialize<List<FeedVideoModel>>(jsonString);

            var SearchVideos = videos.Where(
                video => video.VideoTitle == "Learn C# with mike"
            ).ToList();

            VideoFeed.ItemsSource = SearchVideos;


        }

        private void WinClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
            // Handle the video click event here
        }
    }
}
