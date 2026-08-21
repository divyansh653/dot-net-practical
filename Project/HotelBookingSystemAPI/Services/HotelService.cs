using HotelBookingSystem.Data;
using HotelBookingSystem.Models;
using HotelBookingSystem.Repository;

namespace HotelBookingSystem.Services
{
    public class HotelService : IHotelService
    {
        private readonly AppDbContext context;

        public HotelService(AppDbContext context)
        {
            this.context = context;
        }

        public List<Hotel> GetAllHotels()
        {
            return context.Hotels.ToList();
        }

        public Hotel? GetHotelsById(int id)
        {
            return context.Hotels.Find(id);
        }

        public Hotel AddHotel(Hotel hotel)
        {
            if (hotel.Room <= 0)
            {
                throw new Exception("Number of rooms must be greater than 0.");
            }

            using var transaction = context.Database.BeginTransaction();

            context.Hotels.Add(hotel);
            context.SaveChanges();

            // Hotel Id comes from the identity column.
            // Room numbers: Hotel 1 -> 101, 102...  Hotel 2 -> 201, 202...
            // The loop never creates more rooms than hotel.Room (capacity).
            for (int i = 1; i <= hotel.Room; i++)
            {
                context.Rooms.Add(new Room
                {
                    HotelId = hotel.Id,
                    Room_Number = (hotel.Id * 100) + i,
                    Room_Type = "Standard",
                    Price = 2000,
                    Status = "Available"
                });
            }

            context.SaveChanges();
            transaction.Commit();
            return hotel;
        }
    }
}
