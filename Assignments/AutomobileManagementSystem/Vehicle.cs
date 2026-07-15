using System;

namespace AutomobileManagementSystem
{
    public class Vehicle
    {
        public int VehicleId { get; set; }

        public string VehicleName { get; set; } = "" ;

        public string VehicleType { get; set; } = "" ;

        public string Brand { get; set; } = "" ;

        public double Price { get; set; }

        public int ManufacturingYear { get; set; }
    }
}