using HotelBookingSystem.Models;

namespace HotelBookingSystem.Repository
{
    public interface IHotelService
    {
        List<Hotel> GetAllHotels();
        Hotel? GetHotelsById(int id);
        Hotel AddHotel(Hotel hotel);
    }
}
