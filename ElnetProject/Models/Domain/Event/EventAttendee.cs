using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;
using ElnetProject.Models.Domain.User;

namespace ElnetProject.Models.Domain.Event
{
    public class EventAttendee : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EventId { get; set; }

        [Required]
        public string UserId { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Registered"; // Registered, Confirmed, Cancelled, Attended

        public DateTime RegistrationDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? AmountPaid { get; set; }

        public DateTime? PaymentDate { get; set; }

        [StringLength(100)]
        public string? PaymentReference { get; set; }

        [StringLength(50)]
        public string? TicketNumber { get; set; }

        public bool HasCheckedIn { get; set; }

        public DateTime? CheckInTime { get; set; }

        public DateTime? CheckOutTime { get; set; }

        [StringLength(500)]
        public string? CancellationReason { get; set; }

        [StringLength(500)]
        public string? SpecialRequirements { get; set; }

        public bool WillBringGuests { get; set; }

        public int NumberOfGuests { get; set; }

        [StringLength(500)]
        public string? GuestNames { get; set; }

        public int? Rating { get; set; }

        [StringLength(500)]
        public string? Feedback { get; set; }

        // Navigation properties
        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}