using DB_Artikel_Model;
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

namespace DB_Artikel_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ArticleList articles { get; set; } = new ArticleList();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgrArticles.ItemsSource = articles;
            articles.ReadFromDB("articles.sqlite");
        }
        private void SaveToDB_Click(object sender, RoutedEventArgs e)
        {
            articles.Update("articles.sqlite");
            articles.ReadFromDB("articles.sqlite");
        }

        private void DeleteRow_Click(object sender, RoutedEventArgs e)
        {
            dgrArticles.Items.RemoveAt(dgrArticles.SelectedIndex);
        }
    }
}
