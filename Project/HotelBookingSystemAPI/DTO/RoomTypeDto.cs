using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystem.DTO
{
    public class RoomTypeDto
    {
        [Required(ErrorMessage ="Enter the room name")]
        public string Name { get; set; } = String.Empty;

        [Required(ErrorMessage ="Enter thr Room price")]
        public int Price { get; set; }
        //[Required(ErrorMessage ="Enter the hotel ID")]
        //public int HotelId { get; set; }
        [Required(ErrorMessage ="enter the max. occupancy")]
        public int MaxOccupancy { get; set; }
    }
}
