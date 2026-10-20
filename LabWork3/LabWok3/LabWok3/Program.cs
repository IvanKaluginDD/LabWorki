using System.Security.Cryptography.X509Certificates;

namespace LabWok3
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Role(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public User(int id, string name, int roleId)
        {
            Id = id;
            Name = name;
            RoleId = roleId;
        }
    }

    public class Server
    {
        public Role[] Roles = { new Role(1, "покупатель"), new Role(2, "продавец"), new Role(3, "администратор") };
        public User[] Users = { new User(1, "Сергей", 1), new User(2, "Ольга", 2), new User(3, "Дмитрий", 1), new User(4, "Людмилаы", 1), new User(5, "Владимир", 3) };
    }

    public class Client
    {
        public void PrintClient()
        {
            Console.WriteLine("1: просмотр данных");
            Console.WriteLine("2: ");
            Console.WriteLine("3: детальный просмотр информации о пользователе");
            Console.WriteLine("4: сортировка списка");
            Console.WriteLine("5: добавить пользователя");
            Console.WriteLine("6: изменить данные пользователя");
            Console.WriteLine("7: удалить данные о пользователе");
            Console.WriteLine("8: выход");
            Request(Convert.ToInt16(Console.Read()));
        }

        public void Request(int request)
        {
            Server server = new();
            switch (request)
            {
               1: ; 
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
           
        }
    }
}
