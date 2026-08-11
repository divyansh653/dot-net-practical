using _10_Augest.Models;

namespace _10_Augest.Repository
{
    public interface IPurchaseService
    {
        Purchase CreatePurchase(Purchase purchase);

        List<Purchase> GetPurchases();

        Purchase? GetPurchaseById(int id);
    }
}