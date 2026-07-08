using System;

class assignment1
{
    public void divya()
    {
        int quality = 0;
        int priority = 0;
        int normal = 0;

        for (int id = 1001; id <= 1020; id++)
        {
            Console.Write("Package ID " + id + " : ");

            if (id % 4 == 0)
            {
                Console.WriteLine("Quality Check Required");
                quality++;
            }
            else if (id % 5 == 0)
            {
                Console.WriteLine("Priority Shipment");
                priority++;
            }
            else
            {
                Console.WriteLine("Normal Processing");
                normal++;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Total Packages Processed = 20");
        Console.WriteLine("Quality Check Required = " + quality);
        Console.WriteLine("Priority Shipments = " + priority);
        Console.WriteLine("Normal Packages = " + normal);
    }
}