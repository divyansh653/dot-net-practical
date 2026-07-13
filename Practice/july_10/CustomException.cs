using System;

class CustomException
{
    static void CheckAge(int age)
    {
        if (age < 20)
        {
            throw new InvalidAgeException("Age should be above 20 for getting a driving license");
        }

        Console.WriteLine("Age is 20 and above, eligible for drive");
    }

    static void Main()
    {
        try
        {
            Console.WriteLine("Enter age");
            int age = Convert.ToInt32(Console.ReadLine());
            CheckAge(age);
        }
        catch (InvalidAgeException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid age");
        }
    }
}