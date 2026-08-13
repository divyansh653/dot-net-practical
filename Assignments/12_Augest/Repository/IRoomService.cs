using HotelBookingAPI.Models;

namespace HotelBookingAPI.Repository;

public interface IRoomService
{
    Task<List<Room>> GetAllRooms();

    Task<List<Room>> GetRoomsByHotelId(int hotelId);

    Task<Room?> GetRoomById(int id);

    Task<Room> AddRoom(Room room);
}