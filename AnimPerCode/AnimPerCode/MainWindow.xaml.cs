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

namespace AnimPerCode
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
            // Animation, zB DoubleAnimation
            // binden der Animation zu Control u Property
            // Storyboard

            PointAnimationUsingKeyFrames pakf = new PointAnimationUsingKeyFrames();
            pakf.Duration = new Duration(TimeSpan.FromSeconds(12));

            // KeyFrames definieren
            EasingPointKeyFrame epf1 = new EasingPointKeyFrame(new Point(200, 100), KeyTime.FromPercent(0.25));
            EasingPointKeyFrame epf2 = new EasingPointKeyFrame(new Point(200, 200), KeyTime.FromPercent(0.50));
            EasingPointKeyFrame epf3 = new EasingPointKeyFrame(new Point(100, 200), KeyTime.FromPercent(0.75));
            EasingPointKeyFrame epf4 = new EasingPointKeyFrame(new Point(100, 100), KeyTime.FromPercent(1.00));

            pakf.KeyFrames.Add(epf1);
            pakf.KeyFrames.Add(epf2);
            pakf.KeyFrames.Add(epf3);
            pakf.KeyFrames.Add(epf4);

            Storyboard.SetTargetName(pakf, "elliPath");
            Storyboard.SetTargetProperty(pakf, new PropertyPath(EllipseGeometry.CenterProperty));
            
            ColorAnimationUsingKeyFrames caf = new ColorAnimationUsingKeyFrames();
            caf.Duration = new Duration(TimeSpan.FromSeconds(6));
            ColorKeyFrame cfk1 = new LinearColorKeyFrame(Colors.Red, KeyTime.FromPercent(0.45));
            ColorKeyFrame cfk2 = new LinearColorKeyFrame(Colors.Green, KeyTime.FromPercent(0.50));
            ColorKeyFrame cfk3 = new LinearColorKeyFrame(Colors.Red, KeyTime.FromPercent(0.55));

            caf.KeyFrames.Add(cfk1);
            caf.KeyFrames.Add(cfk2);
            caf.KeyFrames.Add(cfk3);

            Storyboard.SetTargetName(caf, "elliColor");
            Storyboard.SetTargetProperty(caf, new PropertyPath(SolidColorBrush.ColorProperty));

            Storyboard sb = new Storyboard();
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.AutoReverse = true;
            sb.Children.Add(pakf);
            sb.Children.Add(caf);
            sb.Begin(this);

        }
    }
}
