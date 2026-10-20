using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Task2
{
    public class UserService
    {
        private readonly string _filePath;

        public UserService(string filePath)
        {
            _filePath = filePath;
        }
        
        public bool Register(string login, string password, string name, string email, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
            {
                errorMessage = "Заполните все поля";
                return false;
            }

            if (File.Exists(_filePath))
            {
                string[] lines = File.ReadAllLines(_filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length > 0 && parts[0] == login)
                    {
                        errorMessage = "Пользователь с таким логином существует!";
                        return false;
                    }
                }
            }
            string newLine = $"{login};{password};{name};{email}\n";
            File.AppendAllText(_filePath, newLine);
            return true;
        }

        public bool Login(string login, string password, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                errorMessage = "Заполните все поля";
                return false;
            }

            if (!File.Exists(_filePath))
            {
                errorMessage = "Пользователь не найден";
                return false;
            }

            string[] lines = File.ReadAllLines(_filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts.Length >= 2 && parts[0] == login && parts[1] == password)
                {
                   return true;
                }
            }
            errorMessage = "Неверный логин или пароль";
            return true;
        }

        public List<User> ImportFromCsv(string filePath)
        {
            var list = new List<User>();
            if (!File.Exists(filePath)) return list;

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(';');
                if (parts.Length >= 2)
                {
                    list.Add(new User(parts[0], parts[2], parts[3]));
                }
            }
            return list;
        }
    }
}
