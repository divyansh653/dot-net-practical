using System;

namespace StationeryStoreManagement.Exceptions
{
    public class LoginFailedException : Exception
    {
        public LoginFailedException()
            : base("Login Failed! You have entered invalid credentials 3 times. Account Locked.")
        {
        }
    }
}