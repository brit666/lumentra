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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lumentra.View.UserControl
{
    /// <summary>
    /// Interaction logic for VideoCards.xaml
    /// </summary>
    public partial class VideoCards
    {
        public VideoCards()
        {
            InitializeComponent();


        }
        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Raise an event with this card's data
            if (DataContext is FeedVideoModel video)
            {
                VideoClicked?.Invoke(this, video);
            }
        }

        // Custom event to pass the clicked video
        public event EventHandler<FeedVideoModel> VideoClicked;
    }
}
