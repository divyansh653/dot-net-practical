using ShopEase.Data;
using ShopEase.Interfaces;
using ShopEase.Models;
using ShopEase.Utilities;
using System;
using System.Linq;

namespace ShopEase.Services
{
    public class PaymentService : IPayment
    {
        private readonly Random random = new Random();

        public void MakePayment()
        {
            if (DataStore.Orders.Count == 0)
            {
                Console.WriteLine("\nNo Orders Found.");
                return;
            }

            Order order = DataStore.Orders.Last();

            if (order.Status == "Paid")
            {
                Console.WriteLine("\nPayment Already Completed.");
                return;
            }

            Payment payment = new Payment();

            payment.PaymentId = DataStore.Payments.Count + 1001;
            payment.OrderId = order.OrderId;
            payment.Amount = order.TotalAmount;
            payment.PaymentDate = DateTime.Now;

            Console.WriteLine();
            Console.WriteLine("========== PAYMENT ==========");
            Console.WriteLine("1. Credit Card");
            Console.WriteLine("2. Debit Card");
            Console.WriteLine("3. UPI");
            Console.WriteLine("4. Cash On Delivery");

            Console.Write("\nChoose Payment Method : ");

            int choice = int.Parse(Console.ReadLine()!);

            switch (choice)
            {
                case 1:
                    payment.PaymentMethod = "Credit Card";

                    Console.Write("Enter 16 Digit Card Number : ");

                    string creditCard = Console.ReadLine()!;

                    if (creditCard.Length != 16)
                    {
                        Console.WriteLine("Invalid Card Number.");
                        return;
                    }

                    break;

                case 2:
                    payment.PaymentMethod = "Debit Card";

                    Console.Write("Enter 16 Digit Card Number : ");

                    string debitCard = Console.ReadLine()!;

                    if (debitCard.Length != 16)
                    {
                        Console.WriteLine("Invalid Card Number.");
                        return;
                    }

                    break;

                case 3:
                    payment.PaymentMethod = "UPI";

                    Console.Write("Enter UPI ID : ");

                    string upi = Console.ReadLine()!;

                    if (!upi.Contains("@"))
                    {
                        Console.WriteLine("Invalid UPI ID.");
                        return;
                    }

                    break;

                case 4:
                    payment.PaymentMethod = "Cash On Delivery";
                    break;

                default:
                    Console.WriteLine("Invalid Choice.");
                    return;
            }

            int result = random.Next(1, 101);

            if (result <= 80)
                payment.PaymentStatus = "Success";
            else if (result <= 90)
                payment.PaymentStatus = "Pending";
            else
                payment.PaymentStatus = "Failed";

            DataStore.Payments.Add(payment);

            Console.WriteLine();
            Console.WriteLine("========== PAYMENT RESULT ==========");
            Console.WriteLine("Status : " + payment.PaymentStatus);

            if (payment.PaymentStatus == "Success")
            {
                order.Status = "Paid";

                InvoiceGenerator generator = new InvoiceGenerator();

                generator.GenerateInvoice(
                    order.OrderId,
                    order.Customer.Name,
                    order.TotalAmount,
                    payment.PaymentMethod);

                Console.WriteLine("\nPayment Successful.");
            }
            else if (payment.PaymentStatus == "Pending")
            {
                Console.WriteLine("\nPayment Pending.");
            }
            else
            {
                Console.WriteLine("\nPayment Failed.");
            }
        }

        public void PaymentStatus()
        {
            if (DataStore.Payments.Count == 0)
            {
                Console.WriteLine("\nNo Payments Found.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("========== PAYMENT HISTORY ==========");

            foreach (Payment payment in DataStore.Payments)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Payment ID : " + payment.PaymentId);
                Console.WriteLine("Order ID   : " + payment.OrderId);
                Console.WriteLine("Amount     : ₹" + payment.Amount);
                Console.WriteLine("Method     : " + payment.PaymentMethod);
                Console.WriteLine("Status     : " + payment.PaymentStatus);
                Console.WriteLine("Date       : " + payment.PaymentDate);
            }
        }
    }
}