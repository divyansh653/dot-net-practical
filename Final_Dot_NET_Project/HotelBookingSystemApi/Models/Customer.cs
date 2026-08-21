using System.Text.Json.Serialization;

namespace HotelBookingSystem.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public   long Phone {  get; set;}
        [JsonIgnore]
         public ICollection<Reservation>? Reservations { get; set; }
    }
}
