using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;
{
    public class AdminService
    {
        private readonly AppDbContext _context;

        public AdminService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> CreateProduct(Product product)
        {
            return await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> UpdateProduct(int id, Product product)
        {
            var existing = await _context.Products.FindAsync(id);
            if (existing == null) return false;

            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.Price = product.Price;
            existing.Stock = product.Stock;
            existing.ImageUrl = product.ImageUrl;
            existing.Category = product.Category;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
        }

        public async Task<bool> UpdateOrderStatus(int id, string status)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return false;

            var validStatuses = new[] { "pending", "confirmed", "shipped", "delivered", "cancelled" };
            if (!Array.Exists(validStatuses, s => s == status))
            {
                return false;
            }

            order.Status = status;
            order.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users
                .OrderBy(u => u.Username)
                .ToListAsync();
        }

        public async Task<bool> ToggleUserStatus(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            user.IsActive = !user.IsActive;
            user.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
