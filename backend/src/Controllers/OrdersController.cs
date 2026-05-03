using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using backend.Services;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout([FromBody] CheckoutDto dto)
        {
            if (string.IsNullOrEmpty(dto.ShippingAddress) || string.IsNullOrEmpty(dto.ContactPhone))
            {
                return BadRequest(new { message = "Shipping address and contact phone are required" });
            }

            var userId = GetCurrentUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var order = await _orderService.CreateOrder(userId.Value, dto.ShippingAddress, dto.ContactPhone);
            if (order == null)
            {
                return BadRequest(new { message = "Cart is empty or insufficient stock" });
            }

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var userId = GetCurrentUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var orders = await _orderService.GetOrders(userId.Value);
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var userId = GetCurrentUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var order = await _orderService.GetOrderById(id, userId.Value);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPut("{id}/status")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] StatusUpdateDto dto)
        {
            var result = await _orderService.UpdateOrderStatus(id, dto.Status);
            if (!result)
            {
                return BadRequest(new { message = "Invalid order status or order not found" });
            }

            return Ok(new { message = "Order status updated successfully" });
        }

        private int? GetCurrentUserId()
        {
            // In real implementation, extract from JWT token or session
            // For now, return a mock user ID (would come from authentication)
            return 1; // Mock user ID
        }
    }

    public class CheckoutDto
    {
        public string ShippingAddress { get; set; } = string.Empty;
        public string ContactPhone { get; set; } = string.Empty;
    }

    public class StatusUpdateDto
    {
        public string Status { get; set; } = string.Empty;
    }
}
