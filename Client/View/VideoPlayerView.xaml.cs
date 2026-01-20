using LibVLCSharp.Shared;
using LibVLCSharp.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VlcMediaPlayer = LibVLCSharp.Shared.MediaPlayer;

namespace lumentra.View
{
    /// <summary>
    /// Interaction logic for VideoPlayerView.xaml
    /// </summary>
    public partial class VideoPlayerView : Window
    {
        private LibVLC _libVLC;
        VlcMediaPlayer _mediaPlayer;

        public VideoPlayerView()
        {
            InitializeComponent();

            Core.Initialize();

            _libVLC = new LibVLC();
            _mediaPlayer = new LibVLCSharp.Shared.MediaPlayer(_libVLC);

            VideoPlayer.MediaPlayer = _mediaPlayer;
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VideoDemo/CsharpVideo.mp4");

            _mediaPlayer.Play(new Media(_libVLC, path));

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

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string query = SearchBox.Text;
                Window window = new ExploreView(query);
                this.Top = window.Top;
                this.Close();
            }

    }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            _mediaPlayer?.Stop();
            if (VideoPlayer != null)
                VideoPlayer.MediaPlayer = null;

            _mediaPlayer?.Dispose();
            _mediaPlayer = null;

            _libVLC?.Dispose();
            _libVLC = null;
        }

        private void SeekRight_Click(object sender, RoutedEventArgs e)
        {
            if (_mediaPlayer != null)
            {
                var newTime = _mediaPlayer.Time + 10000; // Seek forward by 10 seconds
                if (newTime < _mediaPlayer.Length)
                {
                    _mediaPlayer.Time = newTime;
                }
                else
                {
                    _mediaPlayer.Time = _mediaPlayer.Length; // Go to the end if exceeding length
                }
            }
        }

        private void SeekLeft_Click(object sender, RoutedEventArgs e)
        {
            if (_mediaPlayer != null)
            {
                var newTime = _mediaPlayer.Time - 10000;
                if(newTime < 0)
                {
                    _mediaPlayer.Time = 0;
                }
                else 
                {
                    _mediaPlayer.Time = newTime;
                }
            }
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            if(_mediaPlayer.IsPlaying)
            {
                _mediaPlayer.Pause();
                PauseButton.Content = "\xE768";
            }
            else 
            {
                _mediaPlayer.Play();
                PauseButton.Content = "\xE769";
            }
        }
    }
}
