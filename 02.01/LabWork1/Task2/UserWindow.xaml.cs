using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public ObservableCollection<User> Users { get; set; }
        public UserWindow()
        {
            InitializeComponent();

            Users = new ObservableCollection<User>();

            UserDataGrid.ItemsSource = Users;
            LoadData();
        }

        private void LoadData()
        {
            string filePath = "users.csv";
            if(File.Exists(filePath))
                ParseCsvFile(filePath);
        }

        private void ParseCsvFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach(string line in lines)
            {
                if(string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(';');
                if(parts.Length >= 2)
                {
                    Users.Add(new User(parts[0], parts[2], parts[3]));
                }
            }
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV (*.csv)|*.csv";

            if (openFileDialog.ShowDialog() == true)
            {
                Users.Clear();
                ParseCsvFile(openFileDialog.FileName);
                MessageBox.Show("Данные успешно загружены");
            }
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV (*.csv)|*.csv";
            
            if(saveFileDialog.ShowDialog() == true)
            {
                var lines = new System.Collections.Generic.List<string>();

                foreach (var user in Users)
                {
                    lines.Add($"{user.Login};{user.Name};{user.Email}");
                }

                File.WriteAllLines(saveFileDialog.FileName, lines);
                MessageBox.Show("Данные успешно экспортированы");
            }
        }
    }
}
