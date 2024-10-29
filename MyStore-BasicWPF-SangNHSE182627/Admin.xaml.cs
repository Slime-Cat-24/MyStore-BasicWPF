using Business_Objects;
using MyStore_Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        private readonly IAccountMemberService _accountMemberService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public Admin()
        {
            InitializeComponent();
            setActiveButton("AccountMember");

            _accountMemberService = new AccountMemberService();
            _productService = new ProductService();
            _categoryService = new CategoryService();

            LoadAccountMemberData();
            LoadProductData();
            LoadCategoryData();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void setActiveButton(string activeButton)
        {
            AccountButtonColor.Background = activeButton == "AccountMember" ? Brushes.LightGray : Brushes.Transparent;
            ProductButtonColor.Background = activeButton == "Product" ? Brushes.LightGray : Brushes.Transparent;
            CategoryButtonColor.Background = activeButton == "Category" ? Brushes.LightGray : Brushes.Transparent;

            AccountMemberGrid.Visibility = activeButton == "AccountMember" ? Visibility.Visible : Visibility.Collapsed;
            ProductGrid.Visibility = activeButton == "Product" ? Visibility.Visible : Visibility.Collapsed;
            CategoryGrid.Visibility = activeButton == "Category" ? Visibility.Visible : Visibility.Collapsed;
        }

        private void btnAccountList(object sender, RoutedEventArgs e)
        {
            setActiveButton("AccountMember");
        }
        private void btnProductList(object sender, RoutedEventArgs e)
        {
            setActiveButton("Product");
        }
        private void btnCategoryList(object sender, RoutedEventArgs e)
        {
            setActiveButton("Category");
        }

        private void LoadAccountMemberData()
        {
            List<AccountMember> accounts = _accountMemberService.GetAccountMembers();
            AccountMemberDataGrid.ItemsSource = accounts;
        }
        private void LoadProductData()
        {
            List<Product> products = _productService.GetProducts();
            ProductDataGrid.ItemsSource = products;
        }
        private void LoadCategoryData()
        {
            List<Category> categories = _categoryService.GetCategories();
            CategoryDataGrid.ItemsSource = categories;
        }

        private void btnCreateAccountClick(object sender, RoutedEventArgs e)
        {
            CreateAccountWindow createAccount = new CreateAccountWindow
            {
                Owner = this,
            };
            createAccount.AccountCreated += (s, args) =>
            {
                LoadAccountMemberData();
            };
            createAccount.ShowDialog();

        }
        private void btnDeleteAccountClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedAccounts = AccountMemberDataGrid.SelectedItems.Cast<AccountMember>().ToList();

                if (selectedAccounts.Count == 0)
                {
                    MessageBox.Show("Please select at least one account to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                var deleteConfirmed = MessageBox.Show($"Are you sure you want to delete {selectedAccounts.Count} account(s)?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (deleteConfirmed == MessageBoxResult.Yes)
                {
                    foreach (var account in selectedAccounts)
                    {
                        _accountMemberService.DeleteAccountMember(account.MemberId);
                    }
                    LoadAccountMemberData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select at least one account to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }
        private void btnUpdateAccountClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedAccounts = AccountMemberDataGrid.SelectedItems.Cast<AccountMember>().ToList();
                if (selectedAccounts.Count == 0)
                {
                    MessageBox.Show("No accounts to update.", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                foreach (var account in selectedAccounts)
                {
                    var existingAccount = _accountMemberService.GetAccountMemberById(account.MemberId);

                    if (existingAccount != null && existingAccount != account)
                    {
                        MessageBox.Show($"Member ID {account.MemberId} is already in use. Please use a unique ID.", "Update Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else
                    {
                        _accountMemberService.UpdateAccountMember(account);
                    }
                }
                LoadAccountMemberData();
                MessageBox.Show("Accounts updated successfully.", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select at least one account to update", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnCreateProductClick(object sender, RoutedEventArgs e)
        {
            CreateProductWindow createProduct = new CreateProductWindow
            {
                Owner = this,
            };
            createProduct.ProductCreated += (s, args) =>
            {
                LoadProductData();
            };
            createProduct.ShowDialog();

        }
        private void btnDeleteProductClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedProducts = ProductDataGrid.SelectedItems.Cast<Product>().ToList();

                if (selectedProducts.Count == 0)
                {
                    MessageBox.Show("Please select at least one product to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                var deleteConfirmed = MessageBox.Show($"Are you sure you want to delete {selectedProducts.Count} product(s)?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (deleteConfirmed == MessageBoxResult.Yes)
                {
                    foreach (var product in selectedProducts)
                    {
                        _productService.DeleteProduct(product.ProductId);
                    }
                    LoadProductData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select at least one product to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }
        private void btnUpdateProductClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedProducts = ProductDataGrid.SelectedItems.Cast<Product>().ToList();
                if (selectedProducts.Count == 0)
                {
                    MessageBox.Show("No products to update.", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                foreach (var product in selectedProducts)
                {
                    var existingProduct = _productService.GetProductById(product.ProductId);

                    if (existingProduct != null && existingProduct != product)
                    {
                        MessageBox.Show($"Product ID {product.ProductId} is already in use. Please use a unique ID.", "Update Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else
                    {
                        _productService.UpdateProduct(product);
                    }
                }
                LoadAccountMemberData();
                MessageBox.Show("Products updated successfully.", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select at least one product to update", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnCreateCategoryClick(object sender, RoutedEventArgs e)
        {
            CreateCategoryWindow createCategory = new CreateCategoryWindow
            {
                Owner = this,
            };
            createCategory.CategoryCreated += (s, args) =>
            {
                LoadCategoryData();
            };
            createCategory.ShowDialog();
        }
        private void btnDeleteCategoryClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedCategories = CategoryDataGrid.SelectedItems.Cast<Category>().ToList();

                if (selectedCategories.Count == 0)
                {
                    MessageBox.Show("Please select at least one category to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                var deleteConfirmed = MessageBox.Show($"Are you sure you want to delete {selectedCategories.Count} category(s)?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (deleteConfirmed == MessageBoxResult.Yes)
                {
                    foreach (var category in selectedCategories)
                    {
                        _categoryService.DeleteCategory(category.CategoryId);
                    }
                    LoadCategoryData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select at least one product to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }
        private void btnUpdateCategoryClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedCategories = CategoryDataGrid.SelectedItems.Cast<Category>().ToList();
                if (selectedCategories.Count == 0)
                {
                    MessageBox.Show("No categories to update.", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                foreach (var category in selectedCategories)
                {
                    var existingProduct = _categoryService.GetCategory(category.CategoryId);

                    if (existingProduct != null && existingProduct != category)
                    {
                        MessageBox.Show($"Category ID {category.CategoryId} is already in use. Please use a unique ID.", "Update Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else
                    {
                        _categoryService.UpdateCategory(category);
                    }
                }
                LoadAccountMemberData();
                MessageBox.Show("Categories updated successfully.", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select at least one category to update", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnLogout(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
