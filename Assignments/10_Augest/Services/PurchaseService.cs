using _10_Augest.Data;
using _10_Augest.Models;

namespace _10_Augest.Repository
{
    public class PurchaseService : IPurchaseService
    {
        private readonly AppDbContext context;

        public PurchaseService(AppDbContext context)
        {
            this.context = context;
        }

        public Purchase CreatePurchase(Purchase purchase)
        {
            var customer = context.Customers
                .FirstOrDefault(c => c.Id == purchase.CustomerId);

            if (customer == null)
                throw new ArgumentException("Invalid Customer");

            var vehicle = context.Vehicles
                .FirstOrDefault(v => v.Id == purchase.VehicleId);

            if (vehicle == null)
                throw new ArgumentException("Invalid Vehicle");

            var purchaseAlreadyExists = context.Purchases.Any(p =>
                p.CustomerId == purchase.CustomerId &&
                p.VehicleId == purchase.VehicleId &&
                p.PurchaseDate.Date == purchase.PurchaseDate.Date);

            if (purchaseAlreadyExists)
                throw new ArgumentException("Purchase already exists for the selected date");

            context.Purchases.Add(purchase);
            context.SaveChanges();

            return purchase;
        }

        public List<Purchase> GetPurchases()
        {
            return context.Purchases.ToList();
        }

        public Purchase? GetPurchaseById(int id)
        {
            return context.Purchases.FirstOrDefault(p => p.Id == id);
        }
    }
}