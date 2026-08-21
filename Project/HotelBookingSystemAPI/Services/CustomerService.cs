using HotelBookingSystem.Data;
using HotelBookingSystem.Models;
using HotelBookingSystem.Repository;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Runtime.CompilerServices;

namespace HotelBookingSystem.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext context;
        public CustomerService(AppDbContext context)
        {
            this.context = context;
        }
        public List<Customer> GetCustomers()
        {
            return context.Customers.ToList();
        }
        public Customer GetCustomer(int id)
        {
            return context.Customers.Find(id);
        }
        public Customer AddCustomer(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
            return customer;

        }

        public Customer UpdateCustomer(Customer customer,int id)
        {
            Customer result = context.Customers.Find(id);
            
            if (result != null)
            {
                result.Name = customer.Name;
                result.Email = customer.Email;  
                result.Phone = customer.Phone;
                context.SaveChanges();
                return result;
            }
            return null;
        }
        

        public void DeleteCustomer(int id)
        {
            Customer result = context.Customers.Find(id);
            if (result != null)
            {
                context.Customers.Remove(result);
                context.SaveChanges ();

            }

        }
    }
}
