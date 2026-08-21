using HotelBookingSystem.Models;

namespace HotelBookingSystem.Repository
{
    public interface IBillingService
    {
        Billing? GetBilling(int id);
        List<Billing> GetBillingList();
        Billing CreateBill(int reservationId);
        Billing MakePayment(int id);
    }
}
