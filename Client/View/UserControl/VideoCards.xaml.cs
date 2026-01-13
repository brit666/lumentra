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
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
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

        private void AnimateScale(double value)
        {
            var anim = new DoubleAnimation
            {
                To = value,
                Duration = TimeSpan.FromMilliseconds(120),
                EasingFunction = new QuadraticEase()
            };

            CardScale.BeginAnimation(ScaleTransform.ScaleXProperty, anim);
            CardScale.BeginAnimation(ScaleTransform.ScaleYProperty, anim);
        }

        private void AnimateGlow(double blur, double opacity, Color color)
        {
            CardShadow.Color = color;

            CardShadow.BeginAnimation(DropShadowEffect.BlurRadiusProperty,
                new DoubleAnimation(blur, TimeSpan.FromMilliseconds(150)));

            CardShadow.BeginAnimation(DropShadowEffect.OpacityProperty,
                new DoubleAnimation(opacity, TimeSpan.FromMilliseconds(150)));
        }
        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Raise an event with this card's data
            if (DataContext is FeedVideoModel model)
            {
                VideoClicked?.Invoke(model);
            }

            AnimateScale(1.03);
        }

        // Custom event to pass the clicked video
        public event Action<FeedVideoModel> VideoClicked;

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            Color color =(Color)ColorConverter.ConvertFromString("#FF8A2BE2");
            AnimateScale(1.03);
            AnimateGlow(15, 0.75, color);
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            AnimateScale(1.0);
            AnimateGlow(10, 0.25, Colors.Black);
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AnimateScale(0.99);
        }
    }
}
