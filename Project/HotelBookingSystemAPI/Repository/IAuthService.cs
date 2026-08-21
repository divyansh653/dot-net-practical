namespace HotelBookingSystem.Repository
{
    public interface IAuthService
    {
        string? Login(string userName, string password);

    }
}
