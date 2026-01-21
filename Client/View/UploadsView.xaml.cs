using lumentra.Model;
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
    /// Interaction logic for UploadsView.xaml
    /// </summary>
    public partial class UploadsView : Window
    {
        public UploadsView()
        {
            InitializeComponent();
            FeedVideoFetcher();
        }

        private void WinClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UploadNew_Click(object sender, RoutedEventArgs e)
        {
            // Open file picker or a new upload modal
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Video files (*.mp4;*.mkv)|*.mp4;*.mkv";
            if (openFileDialog.ShowDialog() == true)
            {
                // Handle upload logic
            }
        }
        private void FeedVideoFetcher()
        {
            string jsonString = File.ReadAllText(App.FeedJsonPath);

            var videos = JsonSerializer.Deserialize<List<FeedVideoModel>>(jsonString);

            var SearchVideos = videos.Where(
                video => video.VideoTitle == "Data Structures & Algorithms: Full Course" ||
                         video.VideoTitle == "JavaScript: The Complete Guide"
            ).ToList();

            UploadsFeed.ItemsSource = SearchVideos;


        }

    }
}
