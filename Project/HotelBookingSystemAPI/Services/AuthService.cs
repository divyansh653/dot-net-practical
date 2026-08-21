using HotelBookingSystem.Data;
using HotelBookingSystem.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelBookingSystem.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext context;
        private readonly IConfiguration configuration;

        public AuthService(
            AppDbContext context,
            IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public string? Login(string userName, string password)
        {
            var user = context.Users.FirstOrDefault(x =>
                x.UserName == userName &&
                x.Password == password);

            if (user == null)
            {
                return null;
            }

            var claims = new[]
            {
                // User ID
                new Claim(
                    ClaimTypes.NameIdentifier,
                    user.Id.ToString()
                ),

                // Username
                new Claim(
                    ClaimTypes.Name,
                    user.UserName
                ),

                // Role
                new Claim(
                    ClaimTypes.Role,
                    user.Role
                )
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    configuration["Jwt:Key"]!)
            );

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}