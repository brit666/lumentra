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
    /// Interaction logic for NotificationView.xaml
    /// </summary>
    public partial class NotificationView : Window
    {
        public NotificationView()
        {
            InitializeComponent();
            NotificationFetcher();
        }

        private void WinClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NotificationFetcher()
        {
            string jsonString = File.ReadAllText(App.NotificationsJsonPath);
            var notifications = JsonSerializer.Deserialize<List<NotificationCardModel>>(jsonString);

            NotificationFeed.ItemsSource = notifications;
        }
    }

  
}
