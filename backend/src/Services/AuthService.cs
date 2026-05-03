using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> Register(string username, string email, string password)
        {
            // Implementation will be added here
            return null;
        }

        public async Task<User?> Login(string email, string password)
        {
            // Implementation will be added here
            return null;
        }
    }
}
