using System;

public class abstracteg : FileStorage
{
    public override void Upload(string filename)
    {
        Console.WriteLine("Uploading file to Google Cloud");
    }
}