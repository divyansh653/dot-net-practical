using System;

public abstract class FileStorage
{
    public abstract void Upload(string filename);

    public void ValidateFile()
    {
        Console.WriteLine("Validating file.......");
    }
}