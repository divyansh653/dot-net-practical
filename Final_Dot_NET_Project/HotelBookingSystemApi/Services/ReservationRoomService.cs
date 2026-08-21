//using HotelBookingSystem.Data;
//using HotelBookingSystem.Models;
//using HotelBookingSystem.Repository;

//namespace HotelBookingSystem.Services
//{
//    public class ReservationRoomService : IReservationRoom
//    {
//        private readonly AppDbContext context;
//        public ReservationRoomService(AppDbContext context)
//        {
//            this.context = context;
//        }
//        public List<ReservationRoom> GetAll()

//        {
//            return context.ReservationRooms.ToList();
//        }
//        public ReservationRoom GetReservationRoomsById(int id)
//        {
//            return context.ReservationRooms.Find(id);
//        }
//        public ReservationRoom AddReservationRoom(ReservationRoom room)
//        {
//            var reservation = context.Reservations.FirstOrDefault(x => x.Id == room.ReservationId);

//            if (reservation == null)
//            {
//                throw new Exception("Reservation not found.");
//            }

//            var existingRoom = context.Rooms
//                .FirstOrDefault(x => x.Id == room.RoomId);

//            if (existingRoom == null)
//            {
//                throw new Exception("Room not found.");
//            }

//            // Check room availability
//            string availability = ToCheckAvailability(room);

//            if (availability != "Room is available.")
//            {
//                throw new Exception(availability);
//            }

//            context.ReservationRooms.Add(room);
//            context.SaveChanges();

//            return room;



//        }
//        public void DeleteReservationRoom(int id)
//        {
//            var result = context.ReservationRooms.Find(id);
//            if (result != null)
//            {
//                context.ReservationRooms.Remove(result);
//                context.SaveChanges();
//            }
//        }
//        public string ToCheckAvailability(ReservationRoom rooms)
//        {
//            if (rooms.Check_In_Date >= rooms.Check_Out_Date)
//            {
//                throw new ArgumentException("Check-out date must be after check-in date.");
//            }

//            var existingBooking = context.ReservationRooms.FirstOrDefault(x => x.RoomId == rooms.RoomId && x.Check_In_Date < rooms.Check_Out_Date && x.Check_Out_Date > rooms.Check_In_Date);

//            if (existingBooking != null)
//            {
//                return "Room is not availabe.";
//            }

//            return "Room is available.";
//        }
//    }
//}
