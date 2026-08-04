namespace ShopEase.Models
{
    public class CartItem
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public double TotalPrice
        {
            get
            {
                return Product.Price * Quantity;
            }
        }
    }
}