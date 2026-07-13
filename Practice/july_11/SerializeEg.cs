// Serialization = converts an object into a form (JSON) so it can be saved & shared

using System;
using System.Text.Json;

class SerializeEg
{
    static void Main()
    {
        Employee e = new Employee(101, "abc", 4500);

        string json = JsonSerializer.Serialize(e);
        Console.WriteLine(json);
        // {"EmpId":101,"EmpName":"abc","Salary":4500}

        // deserialize
        Employee e1 = JsonSerializer.Deserialize<Employee>(json);
        Console.WriteLine(e1.EmpName);
    }
}