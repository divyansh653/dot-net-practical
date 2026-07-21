namespace ShopEase.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public int OrderId { get; set; }

        public double Amount { get; set; }

        public string PaymentMethod { get; set; } = "";

        public string PaymentStatus { get; set; } = "";

        public DateTime PaymentDate { get; set; }
    }
}