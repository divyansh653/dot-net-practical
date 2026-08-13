using HotelBookingAPI.Data;
using HotelBookingAPI.Models;
using HotelBookingAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Services;

public class RoomService : IRoomService
{
    private readonly AppDbContext _context;

    public RoomService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Room>> GetAllRooms()
    {
        return await _context.Rooms.ToListAsync();
    }

    public async Task<List<Room>> GetRoomsByHotelId(int hotelId)
    {
        return await _context.Rooms
            .Where(r => r.HotelId == hotelId)
            .ToListAsync();
    }

    public async Task<Room?> GetRoomById(int id)
    {
        return await _context.Rooms
            .Include(r => r.Hotel)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Room> AddRoom(Room room)
    {
        _context.Rooms.Add(room);

        await _context.SaveChangesAsync();

        return room;
    }
}