using Business_Objects;
using MyStore_Services;
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

namespace MyStore_BasicWPF_SangNHSE182627
{
    /// <summary>
    /// Interaction logic for ProductManagement.xaml
    /// </summary>
    public partial class CreateProductWindow : Window
    {
        public event EventHandler ProductCreated;
        private readonly IProductService productService;
        public CreateProductWindow()
        {
            InitializeComponent();
            productService = new ProductService();
        }
        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            int categoryID;
            short unitsInStock;
            decimal unitPrice;
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Name cannot be empty.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!int.TryParse(txtCategoryID.Text, out categoryID))
            {
                MessageBox.Show("Category ID cannot be empty.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!short.TryParse(txtUnitsInStock.Text, out unitsInStock))
            {
                MessageBox.Show("Units in Stock cannot be empty.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!decimal.TryParse(txtUnitPrice.Text, out unitPrice))
            {
                MessageBox.Show("Unit Price cannot be empty.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var newProduct = new Product
            {
                ProductName = txtProductName.Text,
                CategoryId = categoryID,
                UnitsInStock = unitsInStock,
                UnitPrice = unitPrice,
            };
            if (productService.CreateProduct(newProduct))
            {
                MessageBox.Show("Product created successfully!", "Successfull", MessageBoxButton.OK);
                ProductCreated?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            else
            {
                MessageBox.Show("Product created unsuccessfully!", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
