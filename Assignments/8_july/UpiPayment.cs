using System;

public class UpiPayment : PaymentGateway
{
    public override void ProcessPayment(decimal amount)
    {
        Console.WriteLine("Amount paid using UPI");
    }
}