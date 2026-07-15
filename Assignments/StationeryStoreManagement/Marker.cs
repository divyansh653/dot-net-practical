using System;

namespace StationeryStoreManagement.Models
{
    public class Marker : StationeryItem
    {
        public bool Permanent { get; set; }

        public override void DisplayDetails()
        {
            base.DisplayDetails();

            Console.WriteLine("Permanent : " + Permanent);
            Console.WriteLine("--------------------------------------");
        }
    }
}