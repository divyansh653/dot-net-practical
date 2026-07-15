using System;

namespace StationeryStoreManagement.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException()
            : base("Item Not Found!")
        {
        }
    }
}