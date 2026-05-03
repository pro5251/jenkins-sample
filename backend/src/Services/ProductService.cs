using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class ProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProducts(string? search, string? category)
        {
            // Implementation will be added here
            return new List<Product>();
        }

        public async Task<Product?> GetProduct(int id)
        {
            // Implementation will be added here
            return null;
        }
    }
}
