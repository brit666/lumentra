using lumentra.Model;
using System;
using System.Collections.Generic;
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

namespace lumentra.View
{
    /// <summary>
    /// Interaction logic for ContentBrowserView.xaml
    /// </summary>
    public partial class ContentBrowserView : Window
    {
        public ContentBrowserView()
        {
            InitializeComponent();

            Video video =
            (
                new Video
                {
                    VideoId = "1",
                    VideoTitle = "Sample Video",
                    VideoDescription = "This is a sample video description.",
                    VideoDuration = TimeSpan.FromMinutes(5),
                    VideoUrl = "http://example.com/samplevideo",
                    UploadDate = DateTime.Now,
                    ThumbnailUrl = "placeholderText"
                }
            );
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void WinClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void WinMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void WinMin_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;

                maximize_btn.Content = "\xE923";
            }
            else if(this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;

                maximize_btn.Content = "\xE922";
            }
        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text == "Search...")
                SearchBox.Text = "";
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchBox.Text))
                SearchBox.Text = "Search...";
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
