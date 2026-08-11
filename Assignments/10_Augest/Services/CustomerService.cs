using _10_Augest.Data;
using _10_Augest.Models;

namespace _10_Augest.Repository
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext context;

        public CustomerService(AppDbContext context)
        {
            this.context = context;
        }

        public Customer CreateCustomer(Customer customer)
        {
            var emailAlreadyExists = context.Customers
                .Any(c => c.Email == customer.Email);

            if (emailAlreadyExists)
                throw new ArgumentException("Email is already registered");

            context.Customers.Add(customer);
            context.SaveChanges();

            return customer;
        }

        public List<Customer> GetCustomers()
        {
            return context.Customers.ToList();
        }

        public Customer? GetCustomerById(int id)
        {
            return context.Customers.FirstOrDefault(c => c.Id == id);
        }
    }
}