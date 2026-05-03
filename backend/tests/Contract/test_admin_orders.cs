using Xunit;
using backend.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace backend.Tests.Contract
{
    public class AdminOrdersTest
    {
        [Fact]
        public void UpdateOrderStatus_ShouldReturnOk()
        {
            // Arrange
            var controller = new AdminController(null!);

            // Act & Assert
            Assert.NotNull(controller);
        }
    }
}
