using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            // Implementation will be added here
            return Ok(new { message = "Get cart endpoint - to be implemented" });
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart()
        {
            // Implementation will be added here
            return Ok(new { message = "Add to cart endpoint - to be implemented" });
        }
    }
}
