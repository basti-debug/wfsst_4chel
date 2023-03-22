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
using System.Windows.Media.Animation;
using System.Diagnostics;

namespace AnimationStyleTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PointAnimationUsingKeyFrames pakf = new PointAnimationUsingKeyFrames();
            pakf.Duration = new Duration(TimeSpan.FromSeconds(6));

            //KeyFrames definieren 
            EasingPointKeyFrame epf1 = new EasingPointKeyFrame(new Point(100, 100), KeyTime.FromPercent(0.25));
            EasingPointKeyFrame epf2 = new EasingPointKeyFrame(new Point(200,50), KeyTime.FromPercent(0.5));
            EasingPointKeyFrame epf3 = new EasingPointKeyFrame(new Point(300,100), KeyTime.FromPercent(0.7));
            EasingPointKeyFrame epf4 = new EasingPointKeyFrame(new Point(400, 50), KeyTime.FromPercent(0.9));

            pakf.KeyFrames.Add(epf1);
            pakf.KeyFrames.Add(epf2);
            pakf.KeyFrames.Add(epf3);
            pakf.KeyFrames.Add(epf4);
            pakf.RepeatBehavior = RepeatBehavior.Forever;
            pakf.AutoReverse= true;

            Storyboard.SetTargetProperty(pakf, new PropertyPath(EllipseGeometry.CenterProperty));
            Storyboard.SetTargetName(pakf, "andi");

            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;
            da.To = 1;
            da.Duration = TimeSpan.FromSeconds(3);
            da.RepeatBehavior = RepeatBehavior.Forever;
            da.AutoReverse = true;

            Storyboard.SetTargetProperty(da, new PropertyPath(Path.OpacityProperty));
            Storyboard.SetTargetName(da, "rect");

            DoubleAnimation da2 = new DoubleAnimation();
            da2.From = 0;
            da2.To = 1;
            da2.Duration = TimeSpan.FromSeconds(1);
            da2.RepeatBehavior= RepeatBehavior.Forever;
            da2.AutoReverse = true;

            Storyboard.SetTargetProperty(da2, new PropertyPath(Path.OpacityProperty));
            Storyboard.SetTargetName(da2, "stefan");

            Storyboard sb = new Storyboard();
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.AutoReverse = true;
            sb.Children.Add(pakf);
            sb.Children.Add(da);
            sb.Children.Add(da2);
            sb.Begin(this);

        }
    }
}
