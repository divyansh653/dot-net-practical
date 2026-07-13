// file handling means reading data from file or writing data to files

using System;
using System.IO;

public class FileHandling
{
    static void Main()
    {
        File.WriteAllText("emp.txt", "Name: Divyansh");

        string data = File.ReadAllText("emp.txt");
        Console.WriteLine(data);
    }
}