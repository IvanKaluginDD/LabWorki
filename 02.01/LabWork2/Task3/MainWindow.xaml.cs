using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {

            string passwordRegex = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,30}$";
            string loginRegex = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])";
            string emailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            bool isValidPassword = Regex.IsMatch(PasswordBox.Password, passwordRegex);
            bool isValidConfirmPassword = Regex.IsMatch(ConfirmPasswordBox.Password, passwordRegex);
            bool isValidLogin = Regex.IsMatch(LoginTextBox.Text, loginRegex);
            bool isValidEmail = Regex.IsMatch(EmailTextBox.Text, emailRegex);
            if (isValidPassword && isValidConfirmPassword && isValidLogin && isValidEmail)
            {
                MessageBox.Show("Успешная регистрация");
            }
            else if (!isValidPassword)
                MessageBox.Show("Ошибка. Пароль не надежный, проверьте есть ли в нем строчные и прописные буквы, цифры и специальные символы, а также длина от 8 символов");
            else if (!isValidConfirmPassword)
                MessageBox.Show("Ошибка. Пароли не совпадают");
            else if (!isValidLogin)
                MessageBox.Show("Ошибка. ");

        }
    }
}