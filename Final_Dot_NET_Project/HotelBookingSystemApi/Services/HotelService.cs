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

            context.Hotels.Add(hotel);
            context.SaveChanges();
            return hotel;
        }
    }
}
