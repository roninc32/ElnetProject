using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;
using ElnetProject.Models.Domain.User;

namespace ElnetProject.Models.Domain.Billing
{
    public class Payment : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public int BillId { get; set; }

        [Required]
        public string HomeOwnerId { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentNumber { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        public int PaymentMethodId { get; set; }

        [StringLength(100)]
        public string? TransactionReference { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Pending"; // Pending, Completed, Failed, Refunded

        [StringLength(50)]
        public string PaymentType { get; set; } // Regular, Advance, Installment

        public string? ReceiptUrl { get; set; }

        [StringLength(100)]
        public string? ProcessedBy { get; set; }

        public DateTime? ProcessedAt { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        // For refunds
        public int? RefundedFromPaymentId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? RefundAmount { get; set; }

        public DateTime? RefundDate { get; set; }

        [StringLength(500)]
        public string? RefundReason { get; set; }

        // Navigation properties
        [ForeignKey("BillId")]
        public virtual Bill Bill { get; set; }

        [ForeignKey("HomeOwnerId")]
        public virtual HomeOwner HomeOwner { get; set; }

        [ForeignKey("PaymentMethodId")]
        public virtual PaymentMethod PaymentMethod { get; set; }

        [ForeignKey("RefundedFromPaymentId")]
        public virtual Payment RefundedFromPayment { get; set; }
    }
}