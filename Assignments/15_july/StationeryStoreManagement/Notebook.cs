using System;

namespace StationeryStoreManagement.Models
{
    public class Notebook : StationeryItem
    {
        public int Pages { get; set; }
      public string? PaperType { get; set; }

        public override void DisplayDetails()
        {
            base.DisplayDetails();

            Console.WriteLine("Pages      : " + Pages);
            Console.WriteLine("Paper Type : " + PaperType);
            Console.WriteLine("--------------------------------------");
        }
    }
}