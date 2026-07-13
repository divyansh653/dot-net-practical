using System;

class Exceptioneg
{
    public static void Main()
    {
        int a = 50;
        int b = 10;
        int c = a / b;   // division operator is "/" not "\"

        Console.WriteLine(c);   // added so you can see the output
    }
    
}