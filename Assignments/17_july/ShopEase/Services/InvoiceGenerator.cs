using System;

namespace ShopEase.Utilities
{
    public class InvoiceGenerator
    {
        public void GenerateInvoice(int orderId,
                                    string customerName,
                                    double amount,
                                    string paymentMethod)
        {
            Console.WriteLine();
            Console.WriteLine("====================================");
            Console.WriteLine("         SHOPEASE INVOICE");
            Console.WriteLine("====================================");
            Console.WriteLine("Order ID        : " + orderId);
            Console.WriteLine("Customer Name   : " + customerName);
            Console.WriteLine("Amount          : " + amount);
            Console.WriteLine("Payment Method  : " + paymentMethod);
            Console.WriteLine("Date            : " + DateTime.Now);
            Console.WriteLine("====================================");
            Console.WriteLine("Thank You For Shopping!");
            Console.WriteLine("====================================");
        }
    }
}