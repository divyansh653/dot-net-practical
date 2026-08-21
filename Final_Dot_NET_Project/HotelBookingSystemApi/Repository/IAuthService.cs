using HotelBookingSystem.Models;

namespace HotelBookingSystem.Repository
{
    public interface IAuthService
    {
        LoginResponse? Login(string userName, string password);
    }
}
