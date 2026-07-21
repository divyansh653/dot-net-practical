namespace ShopEase.Interfaces
{
    public interface IOrder
    {
        void Checkout();
        void PlaceOrder();
        void ViewOrders();
        void CancelOrder();
        void GenerateInvoice();
    }
}