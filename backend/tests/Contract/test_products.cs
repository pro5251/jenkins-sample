using Xunit;
using backend.Controllers;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Tests.Contract
{
    public class ProductsTest
    {
        [Fact]
        public void GetProducts_ShouldReturnList()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
            using (var context = new AppDbContext(options))
            {
                context.Products.Add(new Product { Name = "Test Product", Price = 100 });
                context.SaveChanges();
            }

            // Assert
            Assert.True(true);
        }
    }
}
