namespace ShopEase.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string Brand { get; set; } = string.Empty;

        public double Discount { get; set; }

        public double Rating { get; set; }
    }
}