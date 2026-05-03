using Xunit;
using backend.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Tests.Integration
{
    public class DatabaseConnectionTest : IDisposable
    {
        private readonly AppDbContext _context;

        public DatabaseConnectionTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer("Server=localhost;Database=TestDB;Integrated Security=true;TrustServerCertificate=True")
                .Options;
            _context = new AppDbContext(options);
        }

        [Fact]
        public void Database_ShouldConnect()
        {
            // Act & Assert
            Assert.True(_context.Database.CanConnect());
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
