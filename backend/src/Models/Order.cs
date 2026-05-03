using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        [Range(0.01, double.MaxValue)]
        public decimal TotalAmount { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "pending";

        [StringLength(50)]
        public string PaymentMethod { get; set; } = "貨到付款";

        [Required]
        public string ShippingAddress { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string ContactPhone { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
