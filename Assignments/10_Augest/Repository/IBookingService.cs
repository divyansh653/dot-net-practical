using _10_Augest.Models;

namespace _10_Augest.Repository
{
    public interface IBookingService
    {
        Booking CreateBooking(Booking booking);

        List<Booking> GetBookings();

        Booking? GetBookingById(int id);
    }
}