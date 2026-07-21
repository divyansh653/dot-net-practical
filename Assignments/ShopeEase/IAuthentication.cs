namespace ShopEase.Interfaces
{
    public interface IAuthentication
    {
        void Register();

        bool AdminLogin();

        bool CustomerLogin();

        void UpdateProfile();

        void ChangePassword();

        void Logout();
    }
}