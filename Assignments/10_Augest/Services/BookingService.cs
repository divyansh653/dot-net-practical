using _10_Augest.Data;
using _10_Augest.Models;

namespace _10_Augest.Repository
{
    public class BookingService : IBookingService
    {
        private readonly AppDbContext context;

        public BookingService(AppDbContext context)
        {
            this.context = context;
        }

        public Booking CreateBooking(Booking booking)
        {
            if (booking.TravelDate.Date < DateTime.UtcNow.Date)
                throw new ArgumentException("Travel Date cannot be in the past");

            var bus = context.Buses.FirstOrDefault(b => b.Id == booking.BusId);

            if (bus == null)
                throw new ArgumentException("Invalid Bus");

            if (booking.SeatNumber > bus.TotalSeats)
                throw new ArgumentException("Seat number must be between 1 to 50");

            var state = context.States.FirstOrDefault(s => s.Id == booking.StateId);

            if (state == null)
                throw new ArgumentException("Invalid destination state");

            var seatAlreadyBooked = context.Bookings.Any(b =>
                b.Id != booking.Id &&
                b.BusId == booking.BusId &&
                b.TravelDate.Date == booking.TravelDate.Date &&
                b.SeatNumber == booking.SeatNumber);

            if (seatAlreadyBooked)
                throw new ArgumentException("This seat is already booked for the selected date");

            var passenger = context.Passengers.FirstOrDefault(p => p.Id == booking.PassengerId);

            if (passenger == null)
                throw new ArgumentException("Invalid Passenger");

            context.Bookings.Add(booking);
            context.SaveChanges();

            return booking;
        }

        public List<Booking> GetBookings()
        {
            return context.Bookings.ToList();
        }

        public Booking? GetBookingById(int id)
        {
            return context.Bookings.FirstOrDefault(b => b.Id == id);
        }
    }
}