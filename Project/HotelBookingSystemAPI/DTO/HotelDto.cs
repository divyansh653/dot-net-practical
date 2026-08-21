using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystem.DTO
{
    public class HotelDto
    {
        [Required(ErrorMessage ="Enter a Hotel name")]
        [StringLength(30,ErrorMessage ="Hotel name can't exceed 30 letters")]
        public string HotelName { get; set; } = string.Empty;

        [Required(ErrorMessage ="Enter the City")]
        [StringLength(30, ErrorMessage = "City name can't exceed 30 letters")]
        public string City { get; set; } = string.Empty;

        //[Required(ErrorMessage ="Enter the Room")]

        //public string Room { get; set; } = string.Empty;
        [Required(ErrorMessage ="Enter the hotel maximum capacity")]
        public int Room {  get; set; }
    }
}
