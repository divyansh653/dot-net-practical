using System;

namespace StationeryStoreManagement.Exceptions
{
    public class InsufficientStockException : Exception
    {
        public InsufficientStockException()
            : base("Insufficient Stock! Purchase quantity exceeds available stock.")
        {
        }
    }
}