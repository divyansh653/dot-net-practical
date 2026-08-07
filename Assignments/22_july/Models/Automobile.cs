using System.ComponentModel.DataAnnotations;

namespace AutomobileSystem_MVC.Models
{
    public class Automobile
    {
        [Required(ErrorMessage = "Vehicle ID is required")]
        public int VehicleId { get; set; }

        [Required(ErrorMessage = "Vehicle Name is required")]
        [StringLength(50)]
        public string VehicleName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Brand is required")]
        [StringLength(30)]
        public string Brand { get; set; } = string.Empty;

        [Required(ErrorMessage = "Model Year is required")]
        [Range(2000, 2035, ErrorMessage = "Enter a valid year")]
        public int ModelYear { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(50000, 10000000, ErrorMessage = "Enter a valid price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Fuel Type is required")]
        public string FuelType { get; set; } = string.Empty;
    }
}