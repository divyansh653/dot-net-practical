using HotelBookingAPI.Models;

namespace HotelBookingAPI.Repository;

public interface ICustomerService
{
    Task<List<Customer>> GetAllCustomers();

    Task<Customer?> GetCustomerById(int id);

    Task<Customer> AddCustomer(Customer customer);
}