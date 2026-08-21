using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystem.DTO
{
    public class ReservationDto
    {
    //    //[Required(ErrorMessage ="Enter your Customer Id")]
    public int CustomerId { get; set; }

      
     

        [Required(ErrorMessage ="Enter the status")]
        public string Status { get; set; } = string.Empty;

        [Required(ErrorMessage ="Enter the No. od guest")]
        public int No_Guest { get; set; }
    }
}
