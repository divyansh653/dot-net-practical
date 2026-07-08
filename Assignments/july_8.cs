using System;

class july_8
{
    public void assignment3()
    {
        int[] sales = { 25000, 32000, 28000, 40000, 35000, 30000 };

        int total = 0;
        int highest = sales[0];
        int lowest = sales[0];

        Console.WriteLine("Employee Sales");

        for (int i = 0; i < 6; i++)
        {
            Console.WriteLine("Employee " + (i + 1) + " = " + sales[i]);

            total = total + sales[i];

            if (sales[i] > highest)
            {
                highest = sales[i];
            }

            if (sales[i] < lowest)
            {
                lowest = sales[i];
            }
        }

        double average = (double)total / 6;

        Console.WriteLine();
        Console.WriteLine("Total Sales = " + total);
        Console.WriteLine("Average Sales = " + average);
        Console.WriteLine("Highest Sales = " + highest);
        Console.WriteLine("Lowest Sales = " + lowest);
    }
}