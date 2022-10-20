using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
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
using VehicleModel;

namespace VehicleFleetApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Vehicle actVehicle;
        private Vehicles vehicles = new Vehicles();
        private Vehicle v;
        private string filename = "vehicle.csv";

        public MainWindow()
        {
            InitializeComponent();

            InsertDummyValues();
        }

        public void InsertDummyValues()
        {
            txtModel.Text = "Polestar 3";
            txtlocation.Text = "main block";
            txtlicens.Text = "LDN 102";
            txttotdist.Text = "1230000";
            sldFuellevel.Value = 50.32;
            rdbAvailable.IsChecked = false;
            rdbunavailable.IsChecked = true;
        }

        private void btnAddVehicle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddVehicle_Click_click(object sender, RoutedEventArgs e)
        {
            string model = txtModel.Text;
            string location = txtlocation.Text;
            string licensplate = txtlicens.Text;
            double fuellevel = sldFuellevel.Value;
            bool availble = rdbAvailable.IsChecked.Value;
            double totalDist = double.Parse(txttotdist.Text);

            Vehicle madeupvehicle = new Vehicle(licensplate, location, fuellevel, availble, model, totalDist);

            //!! IMPORTANT, missing Function!
            // should add madeupvehicle to the list vehicles!
            vehicles.Items.Add(madeupvehicle);
            actVehicle = madeupvehicle;
            AddVisualVehicle(madeupvehicle);
        }

        private void rdbunavailable_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void openlabelclick(object sender, RoutedEventArgs e)
        {
            vehicles.Open(filename);
            lstVehicles.Items.Clear();

            foreach (Vehicle item in vehicles.Items)
            {
                AddVisualVehicle(item);
            }

        }

        private void savelabelclick(object sender, RoutedEventArgs e)
        {
            vehicles.Save(filename);
        }

        private void saveaslableclick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.InitialDirectory = $"c:\\temp";
            dlg.FileName = filename;
            dlg.Filter = "*.csv | Datei";


            if (dlg.ShowDialog().Value)
            {
                filename = dlg.FileName;
                vehicles.Save(filename);
            }
        }

        private void AddVisualVehicle(Vehicle vehicle)
        { 
            StackPanel stackPanel = new StackPanel();
            if (vehicle.avalible)
            {
                stackPanel.Background = Brushes.LightGreen;
            }
            else
            {
                stackPanel.Background = Brushes.OrangeRed;
            }



            //stackpanel for infos top 
            StackPanel topinfos = new StackPanel();
            
            //modelname
            TextBlock model = new TextBlock();
            model.Text = vehicle.model;
            model.FontFamily = new FontFamily("Gotham Bold");
            model.FontSize = 20;
            model.Foreground = Brushes.White;
            model.Padding = new Thickness(10,10,30,0);
            topinfos.Children.Add(model);


            //location
            TextBlock location = new TextBlock();
            location.Text = vehicle.location;
            location.FontFamily = new FontFamily("Gotham Bold");
            location.Foreground = Brushes.Wheat;
            location.Padding = new Thickness(10,0,0,10);
            topinfos.Children.Add(location);

            stackPanel.Children.Add(topinfos);

            
            //fuel
            ProgressBar progressBar = new ProgressBar();
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = vehicle.fuellevel;
            progressBar.Padding = new Thickness(10, 5, 10, 5);
            stackPanel.Children.Add(progressBar);

            TextBlock toataldist = new TextBlock();
            toataldist.Text = $"{vehicle.totaldist:#,##0.0}km";
            toataldist.Padding = new Thickness(10,5, 10, 5);
            stackPanel.Children.Add(toataldist);

            lstVehicles.Items.Add(stackPanel);
        }
    }
}
