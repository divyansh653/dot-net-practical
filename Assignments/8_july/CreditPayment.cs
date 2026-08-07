using System;

public class CreditPayement : PaymentGateway
{
    public override void ProcessPayment(decimal amount)
    {
        Console.WriteLine("Amount paid using Credit ");
    }
}