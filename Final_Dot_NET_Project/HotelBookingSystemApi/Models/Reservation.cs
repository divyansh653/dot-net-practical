using System.Text.Json.Serialization;

namespace HotelBookingSystem.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime Check_In_Date { get; set; }

        public DateTime Check_Out_Date { get; set; }

        public string Status { get; set; } = string.Empty;

        public int No_Guest { get; set; }

        public DateTime Created_At { get; set; }

        [JsonIgnore]
        public Customer? Customer { get; set; }

        public ICollection<ReservationRoom> ReservationRooms { get; set; }
            = new List<ReservationRoom>();
    }
}
