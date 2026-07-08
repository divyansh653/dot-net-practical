using System;

class assignment2
{
    public void view()
    {
        int power;
        int totalPower = 0;
        int maintenance = 0;
        int normal = 0;
        int efficient = 0;

        for (int light = 1; light <= 30; light++)
        {
            power = 80 + (light * 5);

            Console.Write("Street Light " + light + " = " + power + " W : ");

            if (power > 180)
            {
                Console.WriteLine("Maintenance Required");
                maintenance++;
            }
            else if (power >= 140 && power <= 180)
            {
                Console.WriteLine("Normal Operation");
                normal++;
            }
            else
            {
                Console.WriteLine("Energy Efficient");
                efficient++;
            }

            totalPower = totalPower + power;
        }

        double averagePower = (double)totalPower / 30;

        Console.WriteLine();
        Console.WriteLine("Total Power Consumed = " + totalPower + " W");
        Console.WriteLine("Average Power Consumption = " + averagePower + " W");
        Console.WriteLine("Maintenance Required = " + maintenance);
        Console.WriteLine("Normal Operation = " + normal);
        Console.WriteLine("Energy Efficient = " + efficient);
    }
}