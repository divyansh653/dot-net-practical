using HotelBookingAPI.Models;

namespace HotelBookingAPI.Repository;

public interface IHotelService
{
    Task<List<Hotel>> GetAllHotels();

    Task<Hotel?> GetHotelById(int id);

    Task<Hotel> AddHotel(Hotel hotel);
}