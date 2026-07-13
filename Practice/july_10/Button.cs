using System;

class Button
{
    public event Action? Click;   // ✅ explicitly nullable

    public void Press()
    {
        Console.WriteLine("Button is pressed");
        Click?.Invoke();           // ✅ safe call, only invokes if subscribed
    }
}