// LINQ - Language Integrated Query
// used to query collections like arrays, list
// where(): filter data, select(), orderBy(), orderByDescending()
// first(), count(), min(), max(), sum()

using System;          // for Console.WriteLine
using System.Linq;     // required to use LINQ methods like Where()

class linqeg
{
    public void divya()
    {
        // declare an int array with duplicate and unsorted values
        int[] numberss = { 8, 7, 6, 4, 1, 8, 7, 8, 3, 9 };

        // LINQ query using Where():
        // x => x % 2 == 0 is a lambda expression (predicate)
        // it checks each element "x" and keeps it only if x % 2 == 0 (i.e., even numbers)
        // Where() returns a filtered collection (IEnumerable<int>) - NOT executed yet (deferred execution)
        var even = numberss.Where(x => x % 2 == 0);

        // foreach triggers the actual execution of the LINQ query (deferred execution happens here)
        // loops through each even number found in the array, in original order
        foreach (var n in even)
        {
            Console.WriteLine(n);  // prints each even number
        }
    }
}