//extension method adds a new method to an existing class without changing its 
using System;

public static class ExtensionM
{
    public static string ProperCase(this string name)
    {
        return char.ToUpper(name[0]) +
               name.Substring(1).ToLower();
    }
}