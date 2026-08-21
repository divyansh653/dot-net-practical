using HotelBookingSystem.Models;

namespace HotelBookingSystem.Repository
{
    public interface IReservationService
    {
        List<Reservation> GetAll();

        Reservation? GetReservationByID(int id);

        Reservation AddReservation(Reservation reserve);

        void DeleteReservation(int id);
    }
}