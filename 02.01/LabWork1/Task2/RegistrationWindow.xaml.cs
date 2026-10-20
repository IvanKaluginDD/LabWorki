using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Task2
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private readonly UserService _userService = new UserService("users.csv");

        public RegistrationWindow()
        {
            InitializeComponent();
        }


        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string password = PasswordBox.Password.Trim();
            string name = NameTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
           
            if(_userService.Register(login, password, name, email,out string errorMessage))
            {
                MessageBox.Show("Регистрация успешна!");
                UserWindow userWindow = new UserWindow();
                userWindow.Show();
                this.Close();
            }
            else
                MessageBox.Show(errorMessage);

        }
    }
}
