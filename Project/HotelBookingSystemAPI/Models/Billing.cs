namespace HotelBookingSystem.Models
{
    public class Billing
    {
        public int Id { get; set; }
        public int ReservationId {  get; set; }
        public decimal Total_Ammount {  get; set; }
        public string Payment_Status { get; set; } = string.Empty;
        public DateTime? PayementDate  { get; set; }
    }
}
