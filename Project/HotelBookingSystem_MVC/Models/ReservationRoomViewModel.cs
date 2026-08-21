using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystemMVC.Models
{
    public class ReservationRoomViewModel
    {
        public int Id { get; set; }

        public int ReservationId { get; set; }

        public int RoomId { get; set; }

        public RoomViewModel? Room { get; set; }
    }
}
