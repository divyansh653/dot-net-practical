using System.ComponentModel.DataAnnotations;

namespace _10_Augest.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vehicle name is required")]
        [StringLength(50)]
        public string VehicleName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vehicle type is required")]
        [StringLength(30)]
        public string VehicleType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Brand is required")]
        [StringLength(50)]
        public string Brand { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required")]
        [Range(10000, 10000000)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Manufacturing year is required")]
        [Range(1900, 2026)]
        public int ManufacturingYear { get; set; }

        public int CompanyId { get; set; }
    }
}