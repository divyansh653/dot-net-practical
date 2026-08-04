namespace ShopEase.Interfaces
{
    public interface IProduct
    {
        void AddProduct();
        void ViewAllProducts();
        void SearchProduct();
        void UpdateProduct();
        void DeleteProduct();

        void SearchByCategory();
        void SearchByBrand();

        void SortByPrice();
        void SortByRating();

        void LowStockProducts();
    }
}