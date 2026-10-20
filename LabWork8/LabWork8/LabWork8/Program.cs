// Исходный код приложения для рефакторинга.
// Рефакторинг зафиксировать в текстовом документе со столбцами 
// Задание | Исходный код | Код после рефакторинга
// Разнести типы данных по разным файлам.

using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Labwork8
{
    // Контекст базы данных
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=orderManagement.db");
        }
    }

    // Класс Customer (клиент)
    public class Customer
    {
        public string _name;
        public int Id { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    return;

                _name = value; 
            }
        }
        public string Email;
        public List<Order> Orders { get; set; }
    }

    // Класс Order (заказ)
    public class Order
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public bool IsExpress { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }

    // Сервис для работы с клиентами
    public class CustomerService
    {
        private readonly AppDbContext _dbContext;

        public CustomerService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
        }

        public void PrintOrderPrice(int orderId)
        {
            var order = _dbContext.Orders.Include(o => o.Customer).FirstOrDefault(o => o.Id == orderId);
            Console.WriteLine("Total: " + order.Total);
        }

        public void PrintOrderId(int orderId)
        {
            var order = _dbContext.Orders.Include(o => o.Customer).FirstOrDefault(o => o.Id == orderId);
            Console.WriteLine("Order Id: " + order.Id);
        }

        public void PrintOrderEmail(int orderId)
        {
            var order = _dbContext.Orders.Include(o => o.Customer).FirstOrDefault(o => o.Id == orderId);
            Console.WriteLine("Customer Email: " + order.Customer.Email);
        }

        public void PrintOrderIsExpress(int orderId)
        {
            var order = _dbContext.Orders.Include(o => o.Customer).FirstOrDefault(o => o.Id == orderId);
            Console.WriteLine("Express Shipping: " + (order.IsExpress ? "Yes" : "No"));
        }

        public void PrintCustomerInfo(int customerId)
        {
            var customer = _dbContext.Customers.Include(c => c.Orders).FirstOrDefault(c => c.Id == customerId);
            if (customer == null)
            {
                return;
            }
            Console.WriteLine("Customer: " + customer.Name);
            Console.WriteLine("Email: " + customer.Email);
        }
    }

    // Сервис для работы с заказами
    public class OrderService
    {
        private readonly AppDbContext _dbContext;

        public OrderService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }
    }

    public class CalculateFinalPrice
    {
        Order _order;
        static double tax = 0.2;
        static double totalDiscount = 0;
        static double discount = 0.1;
        static double discountPrice = 10000;

        public CalculateFinalPrice(Order order)
        {
            _order = order;
        }

        public double GetCalculateFinalPrice()
        {
            totalDiscount = _order.Total > discountPrice ? _order.Total * discount : totalDiscount;
            return _order.Total - totalDiscount + (_order.Total * tax);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SQLitePCL.Batteries.Init();

            using var dbContext = new AppDbContext();
            dbContext.Database.EnsureCreated();

            var customerService = new CustomerService(dbContext);
            var orderService = new OrderService(dbContext);

            var customer = new Customer { Name = "Alice", Email = "alice@example.com" };
            customerService.AddCustomer(customer);

            var order = new Order { Total = 1200, IsExpress = true, Customer = customer };
            orderService.AddOrder(order);

            customerService.PrintCustomerInfo(customer.Id);
            customerService.PrintOrderId(order.Id);
            customerService.PrintOrderPrice(order.Id);
            customerService.PrintOrderIsExpress(order.Id);
            customerService.PrintOrderEmail(order.Id);

            CalculateFinalPrice calculateFinalPrice = new CalculateFinalPrice(order);
            Console.WriteLine("Final Price: " + calculateFinalPrice.GetCalculateFinalPrice());
        }
    }
}