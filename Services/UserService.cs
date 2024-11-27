using DEMO__ASS9.Data;
using DEMO__ASS9.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace DEMO__ASS9.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
            _secretKey = "abcdefghijklmnopqrstuvwxyzABCDEFHGIJKLMNOPQRSTUVWXYZ123456789!@#$%^&*()"; // Or fetch from configuration
            _issuer = "JwtAuthDemo"; // Or fetch from configuration
            _audience = "JwtAuthDemoUsers"; // Or fetch from configuration
        }

        // User registration
        public bool RegisterUser(User user)
        {
            // Check if the user already exists
            var existingUser = _context.Users.SingleOrDefault(u => u.Email == user.Email);
            if (existingUser != null)
            {
                return false; // User already exists
            }

            // Add the new user to the database
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        // Authenticate a user and generate JWT token
        public string AuthenticateUser(string email, string password)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);

            if (user == null) return null; // Invalid credentials

            // Create JWT token with user role
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role) // Add role claim
            };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
