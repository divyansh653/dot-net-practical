using System.ComponentModel.DataAnnotations;


namespace HotelBookingSystemMVC.Models
{
    public class BillingViewModel
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select a reservation")]
        [Display(Name = "Reservation")]
        public int ReservationId { get; set; }

        [Display(Name = "Total Amount")]
        public decimal Total_Ammount { get; set; }

        [Display(Name = "Payment Status")]
        public string Payment_Status { get; set; } = "Pending";

        [Display(Name = "Payment Date")]
        public DateTime? PayementDate { get; set; }
    }
}
