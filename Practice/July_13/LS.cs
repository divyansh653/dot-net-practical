// L - Liskov Substitution Principle (LSP)
// Derived class should be able to replace its base class
// without changing program's correctness

using System;

class Bird
{
    public virtual void Fly()
    {
        Console.WriteLine("Flying...");
    }
}

class Penguin : Bird
{
    public override void Fly()
    {
        throw new Exception("Penguins cannot fly.");
    }
}

