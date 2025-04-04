using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;
using ElnetProject.Models.Domain.User;

namespace ElnetProject.Models.Domain.Billing
{
    public class Bill : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int HomeOwnerId { get; set; }

        [Required]
        [StringLength(50)]
        public string BillNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [StringLength(50)]
        public string BillType { get; set; } // Maintenance, Utility, Penalty, etc.

        [StringLength(50)]
        public string BillingPeriod { get; set; } // Monthly, Quarterly, Annual, OneTime

        [Column(TypeName = "decimal(18,2)")]
        public decimal PaidAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Pending"; // Pending, Partial, Paid, Overdue

        public bool IsRecurring { get; set; }

        public DateTime? RecurringStartDate { get; set; }

        public DateTime? RecurringEndDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? LateFee { get; set; }

        public int? GracePeriodDays { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        // Navigation properties
        [ForeignKey("HomeOwnerId")]
        public virtual HomeOwner HomeOwner { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}