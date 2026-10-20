using System.IO;
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
using System.Xml.Linq;

namespace Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly UserService _userService = new UserService("users.csv");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AuthorizathionButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string password = PasswordBox.Password.Trim();


            if (_userService.Login(login, password, out string errorMessage))
            {
                MessageBox.Show("Вход успешен");
                UserWindow userWindow = new UserWindow();
                userWindow.Show();
                this.Close();
            }
            else
                MessageBox.Show(errorMessage);
        }

        private void NewAccountButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }
    }
}