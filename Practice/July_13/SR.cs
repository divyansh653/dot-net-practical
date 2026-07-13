// SOLID Principle
// S - Single Responsibility (SRP)
// A class should have only one reason to change, it should
// perform only one responsibility

// Calculate invoice, Print invoice, Save invoice

using System;

class SR
{
    public void CalculateTotal()
    {
        Console.WriteLine("Calculate total");
    }

    public void PrintInvoice()
    {
        Console.WriteLine("Print Invoice");
    }

    public void SaveToDB()
    {
        Console.WriteLine("Saving Invoice");
    }
}

class Program
{
    static void Main(string[] args)
    {
        SR invoice = new SR();

        invoice.CalculateTotal();
        invoice.PrintInvoice();
        invoice.SaveToDB();
    }
}