using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;
using ElnetProject.Models.Domain.Communication;
using ElnetProject.Models.Domain.User;

namespace ElnetProject.Models.Domain.Communication
{
    public class Announcement : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(50)]
        public string AnnouncementType { get; set; } // General, Emergency, Maintenance, Event

        public DateTime? ExpiryDate { get; set; }

        public bool IsUrgent { get; set; }

        public bool RequiresAcknowledgement { get; set; }

        [StringLength(50)]
        public string TargetAudience { get; set; } = "All"; // All, Residents, Staff, Specific

        [StringLength(500)]
        public string? TargetGroups { get; set; } // Comma-separated groups if Specific

        public string? AttachmentUrl { get; set; }

        public int ViewCount { get; set; }

        public int AcknowledgementCount { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Draft"; // Draft, Published, Archived

        // Navigation properties
        public virtual ICollection<AnnouncementAcknowledgement> Acknowledgements { get; set; }
    }
}

public class AnnouncementAcknowledgement
{
    [Key]
    public int Id { get; set; }

    public int AnnouncementId { get; set; }

    public string UserId { get; set; }

    public DateTime AcknowledgedAt { get; set; }

    [ForeignKey("AnnouncementId")]
    public virtual Announcement Announcement { get; set; }

    [ForeignKey("UserId")]
    public virtual ApplicationUser User { get; set; }
}