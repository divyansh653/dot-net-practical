using System;

namespace StationeryStoreManagement.Exceptions
{
    public class InvalidQuantityException : Exception
    {
        public InvalidQuantityException()
            : base("Invalid Quantity! Quantity must be greater than 0.")
        {
        }
    }
}