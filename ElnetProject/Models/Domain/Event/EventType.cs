using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;

namespace ElnetProject.Models.Domain.Event
{
    public class EventType : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Category { get; set; } // Social, Business, Educational, etc.

        [Column(TypeName = "decimal(18,2)")]
        public decimal? DefaultFee { get; set; }

        public bool RequiresApproval { get; set; }

        public bool AllowGuests { get; set; }

        public int? MaxGuestsPerAttendee { get; set; }

        public bool RequiresPayment { get; set; }

        public bool HasFixedSchedule { get; set; }

        public TimeSpan? DefaultDuration { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(100)]
        public string Icon { get; set; }

        public bool IsRecurring { get; set; }

        [StringLength(50)]
        public string? RecurrencePattern { get; set; }

        [StringLength(500)]
        public string? DefaultAgendaTemplate { get; set; }

        [StringLength(500)]
        public string? TermsAndConditions { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Active"; // Active, Inactive, Archived

        // Navigation property
        public virtual ICollection<Event> Events { get; set; }
    }
}