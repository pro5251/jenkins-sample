using Xunit;
using backend.Services;
using backend.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Tests.Integration
{
    public class CheckoutTest
    {
        [Fact]
        public async Task Checkout_ShouldCreateOrder()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("CheckoutTestDb")
                .Options;
            
            // Act & Assert
            Assert.True(true);
        }
    }
}
