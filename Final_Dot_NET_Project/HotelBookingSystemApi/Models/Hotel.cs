using System.Text.Json.Serialization;

namespace HotelBookingSystem.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        public string HotelName { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        // Maximum room capacity for this hotel
        public int Room { get; set; }

        [JsonIgnore]
        public ICollection<Room>? Rooms { get; set; }
    }
}
