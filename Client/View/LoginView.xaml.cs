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
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
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

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmail.Text == "user123@gmail.com" && txtPass.Password == "12345678")
            {
                Window window = new MainFeedView();
                window.Show();
                this.Close();
                App.UserRole = "User";
            }
            else if(txtEmail.Text == "admin@gmail.com" && txtPass.Password == "admin123")
            {
                Window window = new MainFeedView();
                window.Show();
                this.Close();
                App.UserRole = "Admin";
            }
            else if(txtEmail.Text == "creator@gmail.com" && txtPass.Password == "87654321")
            {
                Window window = new MainFeedView();
                window.Show();
                this.Close();
                App.UserRole = "Creator";
            }
            else 
            {
                txtEmailWarning.Visibility = Visibility.Visible;
                txtEmailWarning.Text = "Invalid email or password.";
            }
        }

        private void click_signup(object sender, MouseButtonEventArgs e)
        {
            Window window = new SignupView();
            window.Show();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window window = new PasswordResetView();
            window.Show();
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tb = sender as TextBox;
            if (tb == null) return;

            string email = tb.Text;

            bool isValid =
                email.Contains("@") &&
                email.IndexOf("@") > 0 &&
                email.Contains(".") &&
                email.IndexOf(".") > email.IndexOf("@");

            tb.BorderBrush = isValid ? Brushes.LimeGreen : Brushes.IndianRed;

            txtEmailWarning.Visibility = isValid || string.IsNullOrWhiteSpace(tb.Text) ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
