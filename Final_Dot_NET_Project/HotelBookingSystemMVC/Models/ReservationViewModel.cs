using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystemMVC.Models
{
    public class ReservationViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Select a customer")]
        [Range(1, int.MaxValue, ErrorMessage = "Select a customer")]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Select check-in date")]
        [Display(Name = "Check-in Date")]
        [DataType(DataType.Date)]
        public DateTime Check_In_Date { get; set; }

        [Required(ErrorMessage = "Select check-out date")]
        [Display(Name = "Check-out Date")]
        [DataType(DataType.Date)]
        public DateTime Check_Out_Date { get; set; }

        public string Status { get; set; } = "Booked";

        [Required(ErrorMessage = "Enter the number of guests")]
        [Range(1, 50, ErrorMessage = "Number of guests must be at least 1")]
        [Display(Name = "Number of Guests")]
        public int No_Guest { get; set; }

        public DateTime Created_At { get; set; }

        [Display(Name = "Hotel")]
        public int HotelId { get; set; }

        public List<ReservationRoomViewModel> ReservationRooms { get; set; }
            = new List<ReservationRoomViewModel>();

        public List<int> SelectedRoomIds { get; set; } = new List<int>();
    }
}
