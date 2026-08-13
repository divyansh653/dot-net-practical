using HotelBookingAPI.Data;
using HotelBookingAPI.Models;
using HotelBookingAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Services;

public class CustomerService : ICustomerService
{
    private readonly AppDbContext _context;

    public CustomerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Customer>> GetAllCustomers()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer?> GetCustomerById(int id)
    {
        return await _context.Customers
            .Include(c => c.Bookings)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Customer> AddCustomer(Customer customer)
    {
        _context.Customers.Add(customer);

        await _context.SaveChangesAsync();

        return customer;
    }
}