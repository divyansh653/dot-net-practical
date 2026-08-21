using HotelBookingSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystem.DTO
{
    public class RoomDto
    {
        //[Required(ErrorMessage ="Enter the Room Type")]
        //public RoomType? RoomType { get; set; }

        [Required(ErrorMessage ="Enter the Room No.")]
        public int Room_Number { get; set; }
        //[Required(ErrorMessage ="Enter the Room type Id here")]
        //public int Room_type_id { get; set; }

        [Required(ErrorMessage ="Enter the floor ")]
        public int Floor { get; set; }

    }
}
