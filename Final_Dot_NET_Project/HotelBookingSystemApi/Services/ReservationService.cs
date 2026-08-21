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
                    .ThenInclude(rr => rr.Room)
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

            reserve.Check_In_Date = reserve.Check_In_Date.Date;
            reserve.Check_Out_Date = reserve.Check_Out_Date.Date;

            if (reserve.Check_In_Date >= reserve.Check_Out_Date)
            {
                throw new Exception("Check-out date must be after check-in date.");
            }

            if (reserve.ReservationRooms == null ||
                reserve.ReservationRooms.Count == 0)
            {
                throw new Exception("Please select at least one room.");
            }

            var roomIds = reserve.ReservationRooms
                .Select(rr => rr.RoomId)
                .ToList();

            if (roomIds.Distinct().Count() != roomIds.Count)
            {
                throw new Exception("The same room cannot be selected more than once.");
            }

            var rooms = context.Rooms
                .Where(r => roomIds.Contains(r.Id))
                .ToList();

            if (rooms.Count != roomIds.Count)
            {
                var missing = roomIds.Except(rooms.Select(r => r.Id));
                throw new Exception($"Room {missing.First()} not found.");
            }

            var hotelIds = rooms.Select(r => r.HotelId).Distinct().ToList();

            if (hotelIds.Count != 1)
            {
                throw new Exception("All selected rooms must belong to the selected hotel.");
            }

            foreach (var room in rooms)
            {
                var alreadyBooked = context.ReservationRooms
                    .Any(x =>
                        x.RoomId == room.Id &&
                        context.Reservations.Any(r =>
                            r.Id == x.ReservationId &&
                            r.Status != "Cancelled" &&
                            r.Check_In_Date.Date < reserve.Check_Out_Date &&
                            r.Check_Out_Date.Date > reserve.Check_In_Date
                        )
                    );

                if (alreadyBooked)
                {
                    throw new Exception(
                        $"Room {room.Id} is not available for the selected dates.");
                }
            }

            reserve.ReservationRooms = roomIds
                .Select(id => new ReservationRoom { RoomId = id })
                .ToList();

            reserve.Created_At = DateTime.Now;

            if (string.IsNullOrEmpty(reserve.Status))
            {
                reserve.Status = "Booked";
            }

            context.Reservations.Add(reserve);
            context.SaveChanges();
            return GetReservationByID(reserve.Id)!;
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
