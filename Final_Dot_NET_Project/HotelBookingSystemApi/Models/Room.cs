using System.Text.Json.Serialization;

namespace HotelBookingSystem.Models
{
    public class Room
    {
        public int Id { get; set; }

        public int HotelId { get; set; }

        public int Room_Number { get; set; }

        public string Room_Type { get; set; } = "Standard";

        public int Price { get; set; }

        public string Status { get; set; } = "Available";

        [JsonIgnore]
        public Hotel? Hotel { get; set; }

        [JsonIgnore]
        public ICollection<ReservationRoom>? ReservationRooms { get; set; }
    }
}
