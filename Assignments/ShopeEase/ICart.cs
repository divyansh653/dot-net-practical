namespace ShopEase.Interfaces
{
    public interface ICart
    {
        void AddToCart();
        void RemoveFromCart();
        void UpdateQuantity();
        void ViewCart();
        void ClearCart();
        void ApplyCoupon();
    }
}