using Business_Objects;
using MyStore_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for AccountManagement.xaml
    /// </summary>
    public partial class CreateAccountWindow : Window
    {
        public event EventHandler AccountCreated;

        private readonly IAccountMemberService _accountMemberService;
        private int roleID;
        public CreateAccountWindow()
        {
            InitializeComponent();
            _accountMemberService = new AccountMemberService();
        }
        private void selectedRole(object sender, SelectionChangedEventArgs e)
        {
            if (txtMemberRole.SelectedItem is ComboBoxItem selectedItem)
            {
                if (int.TryParse(selectedItem.Tag.ToString(), out int selectedRoleID))
                {
                    roleID = selectedRoleID;
                }
            }
        }
        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMemberID.Text))
            {
                MessageBox.Show("Member ID cannot be empty.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMemberPassword.Text))
            {
                MessageBox.Show("Password cannot be empty.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Full Name cannot be empty.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEmailAddress.Text))
            {
                MessageBox.Show("Email Address cannot be empty.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var newAccountMember = new AccountMember
            {
                MemberId = txtMemberID.Text,
                MemberPassword = txtMemberPassword.Text,
                FullName = txtFullName.Text,
                EmailAddress = txtEmailAddress.Text,
                MemberRole = roleID,
            };
            if (_accountMemberService.CreateAccountMember(newAccountMember))
            {
                MessageBox.Show("Account created successfully!", "Successfull", MessageBoxButton.OK);
                AccountCreated?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            else
            {
                MessageBox.Show("Account created unsuccessfully!", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
