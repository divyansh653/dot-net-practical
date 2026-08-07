using System;

public class NetBanking : PaymentGateway
{
    public override void ProcessPayment(decimal amount)
    {
        Console.WriteLine("Amount paid using Net Banking");
    }
}