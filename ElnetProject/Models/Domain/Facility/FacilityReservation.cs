using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;
using ElnetProject.Models.Domain.Billing;
using ElnetProject.Models.Domain.User;

namespace ElnetProject.Models.Domain.Facility
{
    public class FacilityReservation : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int FacilityId { get; set; }

        [Required]
        public string HomeOwnerId { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected, Cancelled

        public int ExpectedAttendees { get; set; }

        [StringLength(500)]
        public string? Purpose { get; set; }

        [StringLength(500)]
        public string? RejectionReason { get; set; }

        public DateTime? ApprovedAt { get; set; }

        [StringLength(100)]
        public string? ApprovedBy { get; set; }

        public bool HasPaid { get; set; }

        [StringLength(500)]
        public string? SpecialRequirements { get; set; }

        // Audit fields inherited from BaseEntity will track
        // CreatedAt (reservation request date)
        // CreatedBy (resident who made the reservation)
        // UpdatedAt (last modification date)
        // UpdatedBy (last person to modify the reservation)
        // IsActive (whether the reservation is active or soft-deleted)

        // Navigation properties
        [ForeignKey("FacilityId")]
        public virtual Facility Facility { get; set; }

        [ForeignKey("HomeOwnerId")]
        public virtual HomeOwner HomeOwner { get; set; }

        // Optional payment reference
        public int? PaymentId { get; set; }
        [ForeignKey("PaymentId")]
        public virtual Payment? Payment { get; set; }
    }
}