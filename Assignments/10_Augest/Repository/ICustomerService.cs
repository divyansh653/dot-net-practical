using _10_Augest.Models;

namespace _10_Augest.Repository
{
    public interface ICustomerService
    {
        Customer CreateCustomer(Customer customer);

        List<Customer> GetCustomers();

        Customer? GetCustomerById(int id);
    }
}