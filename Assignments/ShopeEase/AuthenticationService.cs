using ShopEase.Data;
using ShopEase.Interfaces;
using ShopEase.Models;
using System;
using System.Linq;

namespace ShopEase.Services
{
    public class AuthenticationService : IAuthentication
    {
        public Customer? LoggedInCustomer { get; private set; }

        public void Register()
        {
            Customer customer = new Customer();

            Console.Write("Customer ID : ");
            customer.CustomerId = int.Parse(Console.ReadLine()!);

            if (DataStore.Customers.Any(c => c.CustomerId == customer.CustomerId))
            {
                Console.WriteLine("Customer ID already exists.");
                return;
            }

            Console.Write("Name : ");
            customer.Name = Console.ReadLine()!;

            Console.Write("Email : ");
            customer.Email = Console.ReadLine()!;

            if (DataStore.Customers.Any(c => c.Email.Equals(customer.Email,
                StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Email already registered.");
                return;
            }

            Console.Write("Password : ");
            customer.Password = Console.ReadLine()!;

            Console.Write("Phone : ");
            customer.Phone = Console.ReadLine()!;

            Console.Write("Address : ");
            customer.Address = Console.ReadLine()!;

            DataStore.Customers.Add(customer);

            Console.WriteLine("\nRegistration Successful.");
        }

        public bool AdminLogin()
        {
            Console.Write("Username : ");
            string username = Console.ReadLine()!;

            Console.Write("Password : ");
            string password = Console.ReadLine()!;

            if (username == "admin" && password == "admin123")
            {
                Console.WriteLine("\nAdmin Login Successful.");
                return true;
            }

            Console.WriteLine("\nInvalid Username or Password.");
            return false;
        }

        public bool CustomerLogin()
        {
            Console.Write("Email : ");
            string email = Console.ReadLine()!;

            Console.Write("Password : ");
            string password = Console.ReadLine()!;

            LoggedInCustomer = DataStore.Customers.FirstOrDefault(c =>
                c.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                c.Password == password);

            if (LoggedInCustomer != null)
            {
                Console.WriteLine($"\nWelcome {LoggedInCustomer.Name}");
                return true;
            }

            Console.WriteLine("\nInvalid Email or Password.");
            return false;
        }

        public void UpdateProfile()
        {
            if (LoggedInCustomer == null)
            {
                Console.WriteLine("Please login first.");
                return;
            }

            Console.Write("New Name : ");
            LoggedInCustomer.Name = Console.ReadLine()!;

            Console.Write("New Phone : ");
            LoggedInCustomer.Phone = Console.ReadLine()!;

            Console.Write("New Address : ");
            LoggedInCustomer.Address = Console.ReadLine()!;

            Console.WriteLine("\nProfile Updated.");
        }

        public void ChangePassword()
        {
            if (LoggedInCustomer == null)
            {
                Console.WriteLine("Please login first.");
                return;
            }

            Console.Write("Old Password : ");
            string oldPassword = Console.ReadLine()!;

            if (LoggedInCustomer.Password != oldPassword)
            {
                Console.WriteLine("Incorrect Password.");
                return;
            }

            Console.Write("New Password : ");
            LoggedInCustomer.Password = Console.ReadLine()!;

            Console.WriteLine("\nPassword Changed Successfully.");
        }

        public void Logout()
        {
            LoggedInCustomer = null;
            Console.WriteLine("\nLogout Successful.");
        }
    }
}