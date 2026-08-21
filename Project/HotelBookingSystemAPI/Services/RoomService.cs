using HotelBookingSystem.Data;
using HotelBookingSystem.Models;
using HotelBookingSystem.Repository;

namespace HotelBookingSystem.Services
{
    public class RoomService : IRoomService
    {
        private readonly AppDbContext context;

        public RoomService(AppDbContext context)
        {
            this.context = context;
        }

        public List<Room> GetRooms()
        {
            return context.Rooms.ToList();
        }

        public Room? GetRoomById(int id)
        {
            return context.Rooms.Find(id);
        }

        public List<Room> GetRoomsByHotelId(int hotelId)
        {
            return context.Rooms
                .Where(r => r.HotelId == hotelId)
                .OrderBy(r => r.Room_Number)
                .ToList();
        }

        public Room? UpdateRoom(Room room, int id)
        {
            var result = context.Rooms.Find(id);

            if (result == null)
            {
                return null;
            }

            // HotelId and Room_Number stay the same.
            result.Room_Type = room.Room_Type;
            result.Price = room.Price;
            result.Status = room.Status;
            context.SaveChanges();
            return result;
        }

        public List<Room> GetroomsByType(string type)
        {
            var result = context.Rooms
                .Where(x => x.Room_Type.ToLower() == type.ToLower())
                .ToList();

            if (result.Count == 0)
            {
                throw new Exception("No rooms found for this room type.");
            }

            return result;
        }
    }
}
