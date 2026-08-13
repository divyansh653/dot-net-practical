using HotelBookingAPI.Models;

namespace HotelBookingAPI.Repository;

public interface IBookingService
{
    Task<Booking> CreateBooking(
        int customerId,
        List<int> roomIds,
        DateTime checkin,
        DateTime checkout);

    Task<List<Booking>> GetBookingsByCustomerId(int customerId);

    Task<Booking?> GetBookingById(int id);

    Task<bool> CancelBooking(int id);
}