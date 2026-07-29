using System.ComponentModel.DataAnnotations;

namespace _22_july.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is mandatory")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is mandatory")]
        [Range(10, 100000, ErrorMessage = "Price must be between 10 and 100000")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Category is mandatory")]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "Stock is mandatory")]
        [Range(0, 10000, ErrorMessage = "Stock cannot be negative")]
        public int Stock { get; set; }
    }

    public class Stationery : Product
    {
        [Required(ErrorMessage = "Item Name is mandatory")]
        public string ItemName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Brand is mandatory")]
        public string Brand { get; set; } = string.Empty;

        [Required(ErrorMessage = "Quantity is mandatory")]
        [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000")]
        public int Quantity { get; set; }
    }
}