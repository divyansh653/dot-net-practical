using System.Text.Json.Serialization;

namespace HotelBookingSystem.Models
{
    public class ReservationRoom
    {
        public int Id { get; set; }

        public int ReservationId { get; set; }

        public int RoomId { get; set; }

        [JsonIgnore]
        public Reservation? Reservation { get; set; }

        public Room? Room { get; set; }
    }
}