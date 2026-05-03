using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace backend.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> Register(string username, string email, string password)
        {
            // 检查用户名或邮箱是否已存在
            if (await _context.Users.AnyAsync(u => u.Username == username || u.Email == email))
            {
                return null; // 用户名或邮箱已存在
            }

            // 创建新用户
            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = HashPassword(password),
                Role = "customer",
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> Login(string email, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.IsActive);

            if (user == null) return null;

            // 验证密码
            var hashedPassword = HashPassword(password);
            if (user.PasswordHash != hashedPassword) return null;

            return user;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public string GenerateJwtToken(User user)
        {
            // JWT token 生成逻辑 - 简化版本
            // 实际实现应使用 Microsoft.AspNetCore.Authentication.JwtBearer
            return $"mock-jwt-token-{user.Id}-{DateTime.UtcNow.Ticks}";
        }
    }
}
