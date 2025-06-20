using Lab_4.Models;
using Lab_4.Services;
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

namespace Lab_4.Windows
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        private readonly DatabaseService db = new DatabaseService();

        public SearchWindow()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string name = NameBox.Text.Trim();
            string category = CategoryBox.Text.Trim();
            string supplier = SupplierBox.Text.Trim();

            List<DairyProduct> results = db.SearchProducts(name, category, supplier);
            SearchResultsGrid.ItemsSource = results;
        }
    }
}
