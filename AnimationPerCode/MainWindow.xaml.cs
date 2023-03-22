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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimationPerCode
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

        private void Square_Click(object sender, RoutedEventArgs e)
        {
            //Animation, zB DoubleAnimation
            //Binden der Animation zu Control und Property
            //StoryBoard    (fasst alles zusammen)

            PointAnimationUsingKeyFrames pakf = new PointAnimationUsingKeyFrames();
            pakf.Duration = new Duration(TimeSpan.FromSeconds(6));
            //pakf.RepeatBehavior = RepeatBehavior.Forever;
            //pakf.AutoReverse= true;

            // KeyFrames definieren
            EasingPointKeyFrame epf1 = new EasingPointKeyFrame(new Point(200, 100), KeyTime.FromPercent(0.25));
            EasingPointKeyFrame epf2 = new EasingPointKeyFrame(new Point(200, 200), KeyTime.FromPercent(0.5));
            EasingPointKeyFrame epf3 = new EasingPointKeyFrame(new Point(100, 200), KeyTime.FromPercent(0.75));
            EasingPointKeyFrame epf4 = new EasingPointKeyFrame(new Point(100, 100), KeyTime.FromPercent(1.00));

            pakf.KeyFrames.Add(epf1);
            pakf.KeyFrames.Add(epf2);
            pakf.KeyFrames.Add(epf3);
            pakf.KeyFrames.Add(epf4);
            pakf.RepeatBehavior = RepeatBehavior.Forever;
            pakf.AutoReverse = true;

            Storyboard.SetTargetProperty(pakf, new PropertyPath(EllipseGeometry.CenterProperty));
            Storyboard.SetTargetName(pakf,"elliPath");

            ColorAnimationUsingKeyFrames caf= new ColorAnimationUsingKeyFrames();
            caf.Duration = new Duration(TimeSpan.FromSeconds(6));
            ColorKeyFrame ckf1 = new LinearColorKeyFrame(Colors.Red, KeyTime.FromPercent(0.45));
            ColorKeyFrame ckf2 = new LinearColorKeyFrame(Colors.Green, KeyTime.FromPercent(0.50));
            ColorKeyFrame ckf3 = new LinearColorKeyFrame(Colors.Red, KeyTime.FromPercent(0.55));

            caf.KeyFrames.Add(ckf1);
            caf.KeyFrames.Add(ckf2);
            caf.KeyFrames.Add(ckf3);
            caf.RepeatBehavior = RepeatBehavior.Forever;
            caf.AutoReverse = true;

            Storyboard.SetTargetProperty(caf, new PropertyPath(SolidColorBrush.ColorProperty));
            Storyboard.SetTargetName(caf, "elliColor");


            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;
            da.To = 1;
            da.Duration = TimeSpan.FromSeconds(3);
            da.RepeatBehavior = RepeatBehavior.Forever;
            da.AutoReverse = true;

            Storyboard.SetTargetProperty(da, new PropertyPath(Path.OpacityProperty));
            Storyboard.SetTargetName(da, "rect");

            Storyboard sb = new Storyboard();
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.AutoReverse= true;
            sb.Children.Add(pakf);
            sb.Children.Add(caf);
            sb.Children.Add(da);
            sb.Begin(this);
        }
    }
}
