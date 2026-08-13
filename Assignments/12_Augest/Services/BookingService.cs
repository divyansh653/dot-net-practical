using HotelBookingAPI.Data;
using HotelBookingAPI.Models;
using HotelBookingAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Services;

public class BookingService : IBookingService
{
    private readonly AppDbContext _context;

    public BookingService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Booking> CreateBooking(
        int customerId,
        List<int> roomIds,
        DateTime checkin,
        DateTime checkout)
    {
        // Check customer
        var customer = await _context.Customers
            .FirstOrDefaultAsync(c => c.Id == customerId);

        if (customer == null)
        {
            throw new Exception("Customer not found");
        }

        // Check dates
        if (checkin >= checkout)
        {
            throw new Exception("Checkout date must be after check-in date");
        }

        // Check rooms
        var rooms = await _context.Rooms
            .Where(r => roomIds.Contains(r.Id))
            .ToListAsync();

        if (rooms.Count != roomIds.Count)
        {
            throw new Exception("One or more rooms not found");
        }

        // Check room availability
        foreach (var room in rooms)
        {
            var alreadyBooked = await _context.BookingRooms
                .AnyAsync(br =>
                    br.RoomId == room.Id &&
                    br.Booking.Checkin < checkout &&
                    br.Booking.Checkout > checkin &&
                    br.Booking.Status != "Cancelled");

            if (alreadyBooked)
            {
                throw new Exception(
                    $"Room {room.RoomNumber} is already booked for these dates");
            }
        }

        // Calculate number of nights
        int nights = (checkout - checkin).Days;

        // Calculate total amount
        decimal totalAmount = rooms.Sum(r => r.Price) * nights;

        // Create booking
        var booking = new Booking
        {
            CustomerId = customerId,
            Checkin = checkin,
            Checkout = checkout,
            TotalAmt = totalAmount,
            Status = "Confirmed"
        };

        _context.Bookings.Add(booking);

        await _context.SaveChangesAsync();

        // Create BookingRoom records
        foreach (var room in rooms)
        {
            var bookingRoom = new BookingRoom
            {
                BookingId = booking.Id,
                RoomId = room.Id,
                Price = room.Price
            };

            _context.BookingRooms.Add(bookingRoom);
        }

        await _context.SaveChangesAsync();

        return booking;
    }

    public async Task<List<Booking>> GetBookingsByCustomerId(int customerId)
    {
        return await _context.Bookings
            .Include(b => b.BookingRooms)
            .ThenInclude(br => br.Room)
            .Where(b => b.CustomerId == customerId)
            .ToListAsync();
    }

    public async Task<Booking?> GetBookingById(int id)
    {
        return await _context.Bookings
            .Include(b => b.Customer)
            .Include(b => b.BookingRooms)
            .ThenInclude(br => br.Room)
            .FirstOrDefaultAsync(b => b.Id == id);
    }
    public async Task<bool> CancelBooking(int id)
    {
        var booking = await _context.Bookings
            .FirstOrDefaultAsync(b => b.Id == id);

        if (booking == null)
        {
            return false;
        }

        if (booking.Status == "Cancelled")
        {
            return false;
        }

        booking.Status = "Cancelled";

        await _context.SaveChangesAsync();

        return true;
    }
}