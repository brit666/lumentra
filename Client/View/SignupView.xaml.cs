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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class SignupView : Window
    {
        public SignupView()
        {
            InitializeComponent();
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

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {


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

        private void txtConfirmPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string password = txtPass.Password;
            string confirm = txtConfirmPass.Password;

            bool isMatching = password == confirm && !string.IsNullOrEmpty(password);

            txtConfirmPass.BorderBrush = isMatching ? Brushes.LimeGreen : Brushes.IndianRed;

            txtConfirmPassWarning.Visibility = isMatching ? Visibility.Collapsed : Visibility.Visible;
        }

        private void login_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var loginWindow = Application.Current.Windows
                        .OfType<LoginView>()
                        .FirstOrDefault();

            if (loginWindow != null)
            {
                this.Close();
                loginWindow.Activate();
            }
            else
            {
                LoginView login = new LoginView();
                login.Show();
                this.Close();
            }
        }
    }
}
