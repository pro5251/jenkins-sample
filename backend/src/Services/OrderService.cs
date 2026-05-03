using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class OrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Order?> CreateOrder(int userId, string shippingAddress, string contactPhone)
        {
            // 取得用戶購物車
            var cartItems = await _context.CartItems
                .Where(c => c.UserId == userId)
                .Include(c => c.Product)
                .ToListAsync();

            if (cartItems == null || cartItems.Count == 0)
            {
                return null; // 購物車為空
            }

            // 檢查庫存並計算總價
            decimal totalAmount = 0;
            foreach (var item in cartItems)
            {
                if (item.Product.Stock < item.Quantity)
                {
                    return null; // 庫存不足
                }
                totalAmount += item.Product.Price * item.Quantity;
            }

            // 建立訂單
            var order = new Order
            {
                UserId = userId,
                TotalAmount = totalAmount,
                ShippingAddress = shippingAddress,
                ContactPhone = contactPhone,
                Status = "pending",
                CreatedAt = DateTime.UtcNow
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // 建立訂單項目並更新庫存
            foreach (var item in cartItems)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Product.Price
                };
                _context.OrderItems.Add(orderItem);

                // 更新庫存
                item.Product.Stock -= item.Quantity;
            }

            // 清空購物車
            _context.CartItems.RemoveRange(cartItems);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<List<Order>> GetOrders(int userId)
        {
            return await _context.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
        }

        public async Task<Order?> GetOrderById(int orderId, int userId)
        {
            return await _context.Orders
                .Where(o => o.Id == orderId && o.UserId == userId)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateOrderStatus(int orderId, string status)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null) return false;

            // 驗證狀態轉換
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

        public async Task<List<Order>> GetAllOrders()
        {
            return await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
        }
    }
}
