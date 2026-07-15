using System;

namespace StationeryStoreManagement.Exceptions
{
    public class DuplicateItemException : Exception
    {
        public DuplicateItemException()
            : base("Duplicate Item! Item ID already exists.")
        {
        }
    }
}