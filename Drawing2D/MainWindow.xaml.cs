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

namespace Drawing2D
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

        private void polygon1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GradientStopCollection gradientStopCollection = new GradientStopCollection();
            GradientStop gradientStop = new GradientStop()
            {
                Color = Colors.Red,
                Offset = 0
            };
            gradientStopCollection.Add(gradientStop);
            gradientStopCollection.Add(new GradientStop()
            {
                Color = Colors.Green,
                Offset = 1
            });

            polygon1.Fill = new LinearGradientBrush()
            {
                GradientStops = gradientStopCollection
            };

        }

        private void polygon1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            polygon1.Fill = Brushes.Gainsboro;

        }

        private void polygon1_MouseEnter(object sender, MouseEventArgs e)
        {
            polygon1.Stroke = Brushes.Red;
            polygon1.StrokeThickness = 5;
        }

        private void polygon1_MouseLeave(object sender, MouseEventArgs e)
        {
            polygon1.StrokeThickness = 0;
        }
    }
}
