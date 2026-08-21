using HotelBookingSystem.Models;

namespace HotelBookingSystem.Repository
{
    public interface IRoomService
    {
        List<Room> GetRooms();
        Room? GetRoomById(int id);
        List<Room> GetRoomsByHotelId(int hotelId);
        Room AddRoom(Room room);
        Room? UpdateRoom(Room room, int id);
        List<Room> GetroomsByType(string t);
    }
}
