using System;
using System.Collections.Generic;

namespace ShopEase.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public Customer Customer { get; set; }

        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public double TotalAmount { get; set; }

        public string PaymentMode { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
    }
}