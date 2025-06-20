using Lab_4.Models;
using Lab_4.Services;
using Lab_4.Windows;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_4;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly DatabaseService db = new DatabaseService();

    public MainWindow()
    {
        InitializeComponent();
        LoadProducts();
    }

    private void LoadProducts()
    {
        List<DairyProduct> products = db.GetAllProducts();
        ProductsGrid.ItemsSource = products;
    }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        var addWindow = new AddEditWindow();
        addWindow.ShowDialog();
        LoadProducts();
    }

    private void Edit_Click(object sender, RoutedEventArgs e)
    {
        if (ProductsGrid.SelectedItem is DairyProduct selected)
        {
            var editWindow = new AddEditWindow(selected);
            editWindow.ShowDialog();
            LoadProducts(); 
        }
        else
        {
            MessageBox.Show("Оберіть продукт для редагування.");
        }
    }


    private void Search_Click(object sender, RoutedEventArgs e)
    {
        var searchWindow = new SearchWindow();
        searchWindow.ShowDialog();
    }


    private void Order_Click(object sender, RoutedEventArgs e)
    {
        var orderWindow = new OrderWindow();
        orderWindow.ShowDialog();
    }
    private void Delete_Click(object sender, RoutedEventArgs e)
    {
        if (ProductsGrid.SelectedItem is DairyProduct selected)
        {
            var result = MessageBox.Show($"Видалити продукт \"{selected.Name}\"?",
                                         "Підтвердження", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    db.DeleteProduct(selected.Id);
                    LoadProducts(); 
                    MessageBox.Show("Продукт видалено.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при видаленні: " + ex.Message);
                }
            }
        }
        else
        {
            MessageBox.Show("Оберіть продукт для видалення.");
        }
    }

}