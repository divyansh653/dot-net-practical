using System.ComponentModel.DataAnnotations;

namespace _29_july.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vehicle Name is required")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Vehicle Name must contain at least 3 letters")]
        public string VehicleName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Brand is required")]
        public string Brand { get; set; } = string.Empty;

        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; } = string.Empty;

        [Range(2000, 2016, ErrorMessage = "Invalid Year")]
        public int Year { get; set; }

        [Range(1, 10000000, ErrorMessage = "Invalid Price")]
        public decimal Price { get; set; }
    }
}