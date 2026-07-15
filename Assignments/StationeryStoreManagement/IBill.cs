namespace StationeryStoreManagement.Interfaces
{
    public interface IBill
    {
        void GenerateBill(string itemName, double price, int quantity, double discount, double gst, double total);
    }
}