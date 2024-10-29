using Business_Objects;
using MyStore_Services;
using System.Diagnostics;
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

namespace MyStore_BasicWPF_SangNHSE182627
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IAccountMemberService _accountMemberService;

        public MainWindow()
        {
            InitializeComponent();
            _accountMemberService = new AccountMemberService();
        }

        private void Login_btn(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                List<AccountMember> accounts = _accountMemberService.GetAccountMembers();
                if (accounts.Count > 0)
                {
                    var account = accounts.FirstOrDefault(acc => acc.EmailAddress == email);
                    if (account != null)
                    {
                        if (account.MemberPassword == password)
                        {
                            switch (account.MemberRole)
                            {
                                case 1:
                                    Admin admin = new Admin();
                                    admin.Show();
                                    this.Close();
                                    break;
                                case 2:
                                    break;
                                case 3:
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Wrong password!", "Warming", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong email!", "Warming", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Don't have any account in system!", "Warming", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please enter email and password!", "Warming", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Cancel_btn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}