using System.ComponentModel.DataAnnotations;

namespace _23_july.Models
{
    public class Stationery
    {
        [Required(ErrorMessage = "ID is required")]
        [Range(1, 1000, ErrorMessage = "ID must be greater than 0")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Stationery Name is required")]
        [StringLength(50, MinimumLength = 3,
            ErrorMessage = "Name must be between 3 and 50 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(1, 10000, ErrorMessage = "Price must be between 1 and 10000")]
        public decimal Price { get; set; }
    }
}