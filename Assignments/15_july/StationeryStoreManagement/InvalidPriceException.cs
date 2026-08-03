using System;

namespace StationeryStoreManagement.Exceptions
{
    public class InvalidPriceException : Exception
    {
        public InvalidPriceException()
            : base("Invalid Price! Price must be greater than 0.")
        {
        }
    }
}