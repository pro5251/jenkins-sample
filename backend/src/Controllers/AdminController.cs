using Microsoft.AspNetCore.Mvc;
using backend.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("products")]
        public async Task<IActionResult> CreateProduct()
        {
            // Implementation will be added here
            return Ok(new { message = "Admin create product - to be implemented" });
        }

        [HttpPut("products/{id}")]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            // Implementation will be added here
            return Ok(new { message = "Admin update product - to be implemented" });
        }
    }
}
