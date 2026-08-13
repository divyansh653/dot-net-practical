using HotelBookingAPI.Data;
using HotelBookingAPI.Models;
using Microsoft.EntityFrameworkCore;
using HotelBookingAPI.Repository;

namespace HotelBookingAPI.Services;

public class HotelService : IHotelService
{
    private readonly AppDbContext _context;

    public HotelService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Hotel>> GetAllHotels()
    {
        return await _context.Hotels.ToListAsync();
    }

    public async Task<Hotel?> GetHotelById(int id)
    {
        return await _context.Hotels
            .Include(h => h.Rooms)
            .FirstOrDefaultAsync(h => h.Id == id);
    }

    public async Task<Hotel> AddHotel(Hotel hotel)
    {
        _context.Hotels.Add(hotel);

        await _context.SaveChangesAsync();

        return hotel;
    }
}