using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;
using ElnetProject.Models.Domain.User;

namespace ElnetProject.Models.Domain.Billing
{
    public class PaymentMethod : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string HomeOwnerId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; } // CreditCard, BankTransfer, Cash, etc.

        [StringLength(100)]
        public string? CardNumber { get; set; } // Last 4 digits only

        [StringLength(50)]
        public string? CardType { get; set; } // Visa, MasterCard, etc.

        [StringLength(10)]
        public string? ExpiryMonth { get; set; }

        [StringLength(10)]
        public string? ExpiryYear { get; set; }

        [StringLength(100)]
        public string? BankName { get; set; }

        [StringLength(50)]
        public string? AccountNumber { get; set; } // Last 4 digits only

        [StringLength(100)]
        public string? AccountName { get; set; }

        public bool IsDefault { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Active"; // Active, Expired, Suspended

        [StringLength(500)]
        public string? Notes { get; set; }

        // For auto-payment
        public bool AutoPaymentEnabled { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? AutoPaymentLimit { get; set; }

        // Navigation properties
        [ForeignKey("HomeOwnerId")]
        public virtual HomeOwner HomeOwner { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}