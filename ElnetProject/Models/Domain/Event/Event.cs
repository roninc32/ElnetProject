using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;
using ElnetProject.Models.Domain.User;
using ElnetProject.Models.Domain.Facility;

namespace ElnetProject.Models.Domain.Event
{
    public class Event : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EventTypeId { get; set; }

        [Required]
        public string OrganizerId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public int? FacilityId { get; set; }

        [StringLength(200)]
        public string? Location { get; set; }

        public int MaxAttendees { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? RegistrationFee { get; set; }

        public DateTime? RegistrationStartDate { get; set; }

        public DateTime? RegistrationEndDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Draft"; // Draft, Published, Cancelled, Completed

        public bool IsPrivate { get; set; }

        [StringLength(500)]
        public string? TargetAudience { get; set; }

        public string? AgendaItems { get; set; }

        public string? AttachmentUrls { get; set; }

        [StringLength(200)]
        public string? ContactPerson { get; set; }

        [StringLength(50)]
        public string? ContactEmail { get; set; }

        [StringLength(20)]
        public string? ContactPhone { get; set; }

        public bool RequiresApproval { get; set; }

        [StringLength(500)]
        public string? CancellationReason { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        // Navigation properties
        [ForeignKey("EventTypeId")]
        public virtual EventType EventType { get; set; }

        [ForeignKey("OrganizerId")]
        public virtual ApplicationUser Organizer { get; set; }

        [ForeignKey("FacilityId")]
        public virtual FacilityType Facility { get; set; }

        public virtual ICollection<EventAttendee> Attendees { get; set; }
    }
}