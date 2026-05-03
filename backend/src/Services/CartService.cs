using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;
{
    public class CartService
    {
        private readonly AppDbContext _context;

        public CartService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cart>> GetCart(int userId)
        {
            return await _context.CartItems
                .Where(c => c.UserId == userId)
                .Include(c => c.Product)
                .ToListAsync();
        }

        public async Task<Cart?> AddToCart(int userId, int productId, int quantity)
        {
            // 檢查商品是否存在且有庫存
            var product = await _context.Products.FindAsync(productId);
            if (product == null || product.Stock < quantity || product.Status != "active")
            {
                return null;
            }

            // 檢查是否已在購物車中
            var existingItem = await _context.CartItems
                .FirstOrDefaultAsync(c => c.UserId == userId && c.ProductId == productId);

            if (existingItem != null)
            {
                // 更新數量
                existingItem.Quantity += quantity;
                await _context.SaveChangesAsync();
                return existingItem;
            }
            else
            {
                // 新增項目
                var cartItem = new Cart
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = quantity,
                    CreatedAt = DateTime.UtcNow
                };
                _context.CartItems.Add(cartItem);
                await _context.SaveChangesAsync();
                return cartItem;
            }
        }

        public async Task<bool> RemoveFromCart(int userId, int cartItemId)
        {
            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(c => c.Id == cartItemId && c.UserId == userId);

            if (cartItem == null) return false;

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ClearCart(int userId)
        {
            var items = await _context.CartItems
                .Where(c => c.UserId == userId)
                .ToListAsync();

            if (items.Count == 0) return false;

            _context.CartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
            return true;
        }

        public decimal GetCartTotal(int userId)
        {
            return _context.CartItems
                .Where(c => c.UserId == userId)
                .Include(c => c.Product)
                .Sum(c => c.Quantity * c.Product.Price);
        }
    }
}
