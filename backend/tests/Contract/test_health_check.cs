using Xunit;
using backend.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace backend.Tests.Contract
{
    public class HealthCheckTest
    {
        [Fact]
        public void HealthCheck_ShouldReturnOk()
        {
            // Arrange
            var controller = new HealthController();

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }

    [ApiController]
    [Route("api/health")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { status = "healthy" });
        }
    }
}
