using HotelBookingSystem.Data;
using HotelBookingSystem.Models;
using HotelBookingSystem.Repository;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Services
{
    public class ReservationService : IReservationService
    {
        private readonly AppDbContext context;

        public ReservationService(AppDbContext context)
        {
            this.context = context;
        }

        public List<Reservation> GetAll()
        {
            return context.Reservations
                .Include(r => r.ReservationRooms)
                .ToList();
        }

        public Reservation? GetReservationByID(int id)
        {
            return context.Reservations
                .Include(r => r.ReservationRooms)
                    .ThenInclude(rr => rr.Room)
                .FirstOrDefault(r => r.Id == id);
        }

        public Reservation AddReservation(Reservation reserve)
        {
            var customer = context.Customers
                .FirstOrDefault(c => c.Id == reserve.CustomerId);

            if (customer == null)
            {
                throw new Exception("Customer not found.");
            }

            if (reserve.Check_In_Date >= reserve.Check_Out_Date)
            {
                throw new Exception("Check-out date must be after check-in date.");
            }

            if (reserve.ReservationRooms == null ||
                reserve.ReservationRooms.Count == 0)
            {
                throw new Exception("Please select at least one room.");
            }

            foreach (var rr in reserve.ReservationRooms)
            {
                var room = context.Rooms.FirstOrDefault(r => r.Id == rr.RoomId);

                if (room == null)
                {
                    throw new Exception($"Room {rr.RoomId} not found.");
                }

                var alreadyBooked = context.ReservationRooms
                    .Any(x =>
                        x.RoomId == rr.RoomId &&
                        context.Reservations.Any(r =>
                            r.Id == x.ReservationId &&
                            r.Status != "Cancelled" &&
                            r.Check_In_Date < reserve.Check_Out_Date &&
                            r.Check_Out_Date > reserve.Check_In_Date
                        )
                    );

                if (alreadyBooked)
                {
                    throw new Exception($"Room {rr.RoomId} is not available for the selected dates.");
                }
            }

            reserve.Created_At = DateTime.Now;

            if (string.IsNullOrEmpty(reserve.Status))
            {
                reserve.Status = "Booked";
            }

            context.Reservations.Add(reserve);
            context.SaveChanges();
            return reserve;
        }

        public void DeleteReservation(int id)
        {
            var result = context.Reservations.Find(id);

            if (result != null)
            {
                result.Status = "Cancelled";
                context.SaveChanges();
            }
        }
    }
}
