using System.ComponentModel.DataAnnotations;

namespace _10_Augest.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int VehicleId { get; set; }

        [Required(ErrorMessage = "Purchase date is required")]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(10000, 10000000)]
        public decimal Price { get; set; }
    }
}