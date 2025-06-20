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
    /// Interaction logic for AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        private readonly DatabaseService db = new DatabaseService();
        private readonly DairyProduct editingProduct;

        public AddEditWindow()
        {
            InitializeComponent();
        }

        public AddEditWindow(DairyProduct productToEdit) : this()
        {
            editingProduct = productToEdit;
            this.Title = "Редагувати продукт";

            NameBox.Text = productToEdit.Name;
            CategoryBox.Text = productToEdit.Category;
            TypeBox.Text = productToEdit.Type;
            ExpirationDatePicker.SelectedDate = productToEdit.ExpirationDate;
            SupplierBox.Text = productToEdit.Supplier;
            PriceBox.Text = productToEdit.Price.ToString();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = new DairyProduct
                {
                    Name = NameBox.Text,
                    Category = CategoryBox.Text,
                    Type = TypeBox.Text,
                    ExpirationDate = ExpirationDatePicker.SelectedDate ?? DateTime.Today,
                    Supplier = SupplierBox.Text,
                    Price = decimal.Parse(PriceBox.Text)
                };

                if (editingProduct == null)
                {
                    db.AddProduct(product);
                    MessageBox.Show("Продукт додано!");
                }
                else
                {
                    product.Id = editingProduct.Id;
                    db.UpdateProduct(product);
                    MessageBox.Show("Продукт оновлено!");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }
    }
}
