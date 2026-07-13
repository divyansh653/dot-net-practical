// delegate - type that holds a reference to a method
// similar to function pointer
// func - return an values
using System;

class delegateeg {

    // built-in delegate func<T1, T2, TResult> can hold a method 
    // that takes 2 parameters (int, int) and returns an int
    static Func<int, int, int> add = (a, b) => a + b;

    // custom delegate declaration
    // delegate type "MessageDelegate" can hold a reference to 
    // any method that takes a string parameter and returns void
    delegate void MessageDelegate(string msg);

    // a method matching the MessageDelegate signature (string param, void return)
    static void Display(string message) {
        Console.WriteLine(message);
    }

    static void Main() {
        // calling the built-in delegate (Func) directly
        Console.WriteLine(add(588, 756)); // Output: 1344

        // assigning the Display method to a MessageDelegate variable
        // m now "points to" the Display method
        MessageDelegate m = Display;

        // invoking the delegate - this calls Display("Hello, i m learning dot net c#")
        m("Hello, i am learning dot net c#");

       Button bt = new Button();               // create a new Button object
       bt.Click += () => Console.WriteLine("Click event");  // subscribe to the Click event
       bt.Press();    
       
       linqueg x =new linqueg();
       x.divya();                          // triggers Press(), which invokes Click

    }
}
