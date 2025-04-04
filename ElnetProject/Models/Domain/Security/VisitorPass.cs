using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;
using ElnetProject.Models.Domain.User;

namespace ElnetProject.Models.Domain.Security
{
    public class VisitorPass : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int HomeOwnerId { get; set; }

        [Required]
        [StringLength(100)]
        public string VisitorName { get; set; }

        [StringLength(20)]
        public string? VisitorIdNumber { get; set; }

        [Required]
        public DateTime ValidFrom { get; set; }

        [Required]
        public DateTime ValidUntil { get; set; }

        [Required]
        [StringLength(50)]
        public string Purpose { get; set; }

        [StringLength(20)]
        public string? VehiclePlateNumber { get; set; }

        [StringLength(50)]
        public string PassType { get; set; } = "OneTime"; // OneTime, Regular, Contractor

        [StringLength(50)]
        public string Status { get; set; } = "Active"; // Active, Used, Expired, Cancelled

        public DateTime? CheckInTime { get; set; }

        public DateTime? CheckOutTime { get; set; }

        [StringLength(100)]
        public string? CheckedInBy { get; set; }

        [StringLength(100)]
        public string? CheckedOutBy { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        // QR code or barcode for scanning
        [StringLength(100)]
        public string? PassCode { get; set; }

        // Navigation property
        [ForeignKey("HomeOwnerId")]
        public virtual HomeOwner HomeOwner { get; set; }
    }
}