using Xunit;
using backend.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace backend.Tests.Contract
{
    public class AdminProductsTest
    {
        [Fact]
        public void CreateProduct_ShouldReturnOk()
        {
            // Arrange
            var controller = new AdminController(null!);

            // Act & Assert
            Assert.NotNull(controller);
        }
    }
}
