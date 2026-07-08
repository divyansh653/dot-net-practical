using System;
using System.Collections.Generic;

class collection
{
    public void display()
    {
        List<string> names = new List<string>(); // Create a list

        names.Add("Mayur");
        names.Add("Divyansh");
        names.Add("Saloni");
        names.Add("Achal");
        names.Add("Kartik");
        names.Add("Vaishnavi");
        names.Add("Mohammed");
        names.Add("Aditya");

        foreach (string f in names)
        {
            Console.WriteLine(f);
        }
    }
}