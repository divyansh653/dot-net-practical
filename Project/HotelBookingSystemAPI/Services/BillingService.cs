using HotelBookingSystem.Data;
using HotelBookingSystem.Models;
using HotelBookingSystem.Repository;

namespace HotelBookingSystem.Services
{
    public class BillingService : IBillingService
    {
        private readonly AppDbContext context;

        public BillingService(AppDbContext context)
        {
            this.context = context;
        }

        public Billing? GetBilling(int id)
        {
            return context.Billing.Find(id);
        }

        public List<Billing> GetBillingList()
        {
            return context.Billing.ToList();
        }

        public Billing CreateBill(int reservationId)
        {
            var reservation = context.Reservations.Find(reservationId);

            if (reservation == null)
            {
                throw new Exception("Reservation not found.");
            }

            var existing = context.Billing
                .FirstOrDefault(b => b.ReservationId == reservationId);

            if (existing != null)
            {
                return existing;
            }

            var rooms = context.ReservationRooms
                .Where(x => x.ReservationId == reservationId)
                .ToList();

            int nights = (reservation.Check_Out_Date - reservation.Check_In_Date).Days;

            if (nights <= 0)
            {
                nights = 1;
            }

            decimal amount = 0;

            foreach (var rr in rooms)
            {
                var room = context.Rooms.Find(rr.RoomId);

                if (room != null)
                {
                    amount += room.Price * nights;
                }
            }

            var bill = new Billing
            {
                ReservationId = reservationId,
                Total_Ammount = amount,
                Payment_Status = "Pending",
                PayementDate = null
            };

            context.Billing.Add(bill);
            context.SaveChanges();
            return bill;
        }

        public Billing MakePayment(int id)
        {
            var result = context.Billing.Find(id);

            if (result == null)
            {
                throw new Exception("Bill not found.");
            }

            if (result.Payment_Status == "Paid")
            {
                throw new Exception("Payment has already been completed.");
            }

            result.Payment_Status = "Paid";
            result.PayementDate = DateTime.Now;
            context.SaveChanges();
            return result;
        }
    }
}
