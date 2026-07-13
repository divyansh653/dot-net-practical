using System;

// Without Generics
class Genericseg
{
    void Printit(int number)
    {
        Console.WriteLine(number);
    }

    void Printit1(string namee)
    {
        Console.WriteLine(namee);
    }
}

// Generics - write one method for all data types


public class Genericseg<T>
{
    public void Print(T value)
    {
        Console.WriteLine(value);
    }
}