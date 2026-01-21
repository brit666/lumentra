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
    /// Interaction logic for AdminPanelView.xaml
    /// </summary>
    public partial class AdminPanelView : Window
    {
        public AdminPanelView()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Window loginWindow = new LoginView();
            loginWindow.Show();
            this.Close();
        }

        private void LoadDashboardData()
        {
            // Mock data for the list
            var items = new List<dynamic>
        {
            new { ID = 1, Name = "User: Alex_Streamer", Status = "Active", Date = "2024-05-12" },
            new { ID = 2, Name = "Video: Pro Gaming Setup", Status = "Published", Date = "2024-05-14" },
            new { ID = 3, Name = "User: Sarah_Editor", Status = "Pending", Date = "2024-05-15" },
            new { ID = 4, Name = "Video: How to stream 4K", Status = "Processing", Date = "2024-05-16" }
        };

        }
    }
}
