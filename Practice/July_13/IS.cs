// I - Interface Segregation Principle (ISP)
// Clients should not be forced to implement methods
// they do not use

using System;

interface Program
{
    void Work();
    void Walk();
}

interface Program1
{
    void Eat();
}

class Human : Program, Program1
{
    public void Work()
    {
        Console.WriteLine("Human is Working");
    }

    public void Walk()
    {
        Console.WriteLine("Human is Walking");
    }

    public void Eat()
    {
        Console.WriteLine("Human is Eating");
    }
}

class Robot : Program
{
    public void Work()
    {
        Console.WriteLine("Robot is Working");
    }

    public void Walk()
    {
        Console.WriteLine("Robot is Walking");
    }
}

