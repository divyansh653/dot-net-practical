using HotelBookingSystem.Data;
using HotelBookingSystem.Models;
using HotelBookingSystem.Repository;
using Microsoft.EntityFrameworkCore;

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

        public Room AddRoom(Room room)
        {
            if (room.Id <= 0)
            {
                throw new Exception("Room ID is required.");
            }

            if (room.HotelId <= 0)
            {
                throw new Exception("Please select a hotel.");
            }

            if (room.Room_Number <= 0)
            {
                throw new Exception("Room number is required.");
            }

            var hotel = context.Hotels.Find(room.HotelId);

            if (hotel == null)
            {
                throw new Exception("Hotel not found.");
            }

            if (context.Rooms.Any(r => r.Id == room.Id))
            {
                throw new Exception("Room ID already exists.");
            }

            if (context.Rooms.Any(r =>
                r.HotelId == room.HotelId &&
                r.Room_Number == room.Room_Number))
            {
                throw new Exception("Room number already exists for this hotel.");
            }

            if (string.IsNullOrWhiteSpace(room.Room_Type))
            {
                room.Room_Type = "Standard";
            }

            if (string.IsNullOrWhiteSpace(room.Status))
            {
                room.Status = "Available";
            }

            // Rooms.Id is still an IDENTITY column. IDENTITY_INSERT lets the
            // administrator supply the Id without recreating the table.
            using var transaction = context.Database.BeginTransaction();

            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Rooms ON");

            try
            {
                context.Rooms.Add(room);
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new Exception("Room ID already exists.");
            }
            finally
            {
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Rooms OFF");
            }

            transaction.Commit();
            return room;
        }

        public Room? UpdateRoom(Room room, int id)
        {
            var result = context.Rooms.Find(id);

            if (result == null)
            {
                return null;
            }

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
