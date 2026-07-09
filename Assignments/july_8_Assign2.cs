using System;
using System.Collections.Generic;

class july_8_Assign2
{
    public void Assign2()
    {
        
        List<string> books = new List<string>()
        {
            "MATHS",
            "ENGLISH",
            "SCIENCE",
            "HISTORY"
        };

        
        Console.WriteLine("Available Books:");
        foreach (string book in books)
        {
            Console.WriteLine(book);
        }

        
        books.Add("MARATHI");

        
        books.Remove("SCIENCE");

        
        Console.WriteLine("\nUpdated Book List:");
        foreach (string book in books)
        {
            Console.WriteLine(book);
        }

    
        Console.WriteLine("\nTotal Books = " + books.Count);
    }
}