using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class User
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public User(string login, string name, string email)
        {
            Login = login;
            Name = name;
            Email = email;
        }
    }
}
