using System;

class CompiletimePoly
{
    // Search by Employee ID
    public void Search(int id)
    {
        Console.WriteLine("Search by Employee id");
    }

    // Search by Employee Name
    public void Search(string firstName, string lastName)
    {
        Console.WriteLine("Search by name");
    }

    // Search by Phone Number
    public void Search(long phone)
    {
        Console.WriteLine("Search by phone");
    }
}