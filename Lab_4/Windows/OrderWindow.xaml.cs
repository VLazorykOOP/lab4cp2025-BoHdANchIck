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
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        private readonly DatabaseService db = new DatabaseService();

        public OrderWindow()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            List<DairyProduct> products = db.GetAllProducts();
            ProductsComboBox.ItemsSource = products;
            ProductsComboBox.DisplayMemberPath = "Name";
        }

        private void ConfirmOrder_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsComboBox.SelectedItem is DairyProduct selectedProduct)
            {
                if (int.TryParse(QuantityBox.Text, out int quantity) && quantity > 0)
                {
                    MessageBox.Show($"Замовлення підтверджено:\n{selectedProduct.Name} — {quantity} шт.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Введіть коректну кількість!");
                }
            }
            else
            {
                MessageBox.Show("Оберіть продукт!");
            }
        }
    }
}
