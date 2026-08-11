using System.ComponentModel.DataAnnotations;

namespace _10_Augest.Models
{
    public class Bus
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "BusNumber is required")]
        [StringLength(50)]
        public string BusNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Total Seat is required")]
        [Range(1, 50)]
        public int TotalSeats { get; set; }

        [Required(ErrorMessage = "BusType is required")]
        public string BusType { get; set; } = string.Empty;
    }
}