using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class CartService
    {
        private readonly AppDbContext _context;

        public CartService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddToCart(int userId, int productId, int quantity)
        {
            // Implementation will be added here
        }

        public async Task<List<Cart>> GetCart(int userId)
        {
            // Implementation will be added here
            return new List<Cart>();
        }
    }
}
