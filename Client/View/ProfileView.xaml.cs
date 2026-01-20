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
    /// Interaction logic for ProfileView.xaml
    /// </summary>
    public partial class ProfileView : Window
    {
        public ProfileView()
        {
            InitializeComponent();

            if(App.UserRole == "Admin")
            {
                UsernameText.Text = "Admin User";
                RoleBadge.Text = "Administrator";
                ViewCount.Visibility = Visibility.Collapsed;
                ViewLabel.Visibility = Visibility.Collapsed;
                VideoCount.Visibility = Visibility.Collapsed;
                VideoLabel.Visibility = Visibility.Collapsed;
                FollowerCount.Visibility = Visibility.Collapsed;
                FollowerLabel.Visibility = Visibility.Collapsed;
            }
            else if(App.UserRole == "User")
            {
                UsernameText.Text = "User123";
                RoleBadge.Text = "Standard User";
                FollowerCount.Text = "0";
                ViewCount.Text = "0";
                VideoCount.Text = "0";
            }
            else if(App.UserRole == "Creator")
            {

                UsernameText.Text = "Mike";
                RoleBadge.Text = "Content Creator";
                FollowerCount.Text = "120k";
                ViewCount.Text = "2.2M";
                VideoCount.Text = "12";
            }
        }

        public void WinClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
