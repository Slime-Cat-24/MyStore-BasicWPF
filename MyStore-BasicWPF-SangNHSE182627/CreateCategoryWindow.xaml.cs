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
    /// Interaction logic for CreateCategoryWindow.xaml
    /// </summary>
    public partial class CreateCategoryWindow : Window
    {
        public event EventHandler CategoryCreated;
        private readonly ICategoryService _categoryService;
        public CreateCategoryWindow()
        {
            InitializeComponent();
            _categoryService = new CategoryService();
        }
        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Name cannot be empty.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var newCategory = new Category
            {
                CategoryName = txtCategoryName.Text,
            };
            if (_categoryService.CreateCategory(newCategory))
            {
                MessageBox.Show("Category created successfully!", "Successfull", MessageBoxButton.OK);
                CategoryCreated?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            else
            {
                MessageBox.Show("Category created unsuccessfully!", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
