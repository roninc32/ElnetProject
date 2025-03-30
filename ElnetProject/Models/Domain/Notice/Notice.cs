using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;
using ElnetProject.Models.Domain.User;

namespace ElnetProject.Models.Domain.Notice
{
    public class Notice : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int NoticeTypeId { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Draft"; // Draft, Published, Archived, Expired

        [StringLength(50)]
        public string Priority { get; set; } = "Normal"; // Low, Normal, High, Urgent

        public bool IsPublished { get; set; }

        public string TargetAudience { get; set; } // JSON array of audience types

        public string AttachmentUrls { get; set; } // JSON array of URLs

        public int ViewCount { get; set; }

        public bool RequiresAcknowledgement { get; set; }

        public DateTime? LastViewDate { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        // Navigation properties
        [ForeignKey("NoticeTypeId")]
        public virtual NoticeType NoticeType { get; set; }

        [ForeignKey("AuthorId")]
        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<NoticeAcknowledgement> Acknowledgements { get; set; }
        public virtual ICollection<NoticeView> Views { get; set; }
    }

    public class NoticeView : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int NoticeId { get; set; }

        [Required]
        public string UserId { get; set; }

        public DateTime ViewedAt { get; set; }

        [StringLength(100)]
        public string IpAddress { get; set; }

        [StringLength(200)]
        public string UserAgent { get; set; }

        // Navigation properties
        [ForeignKey("NoticeId")]
        public virtual Notice Notice { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }

    public class NoticeAcknowledgement : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int NoticeId { get; set; }

        [Required]
        public string UserId { get; set; }

        public DateTime AcknowledgedAt { get; set; }

        [StringLength(500)]
        public string Comments { get; set; }

        // Navigation properties
        [ForeignKey("NoticeId")]
        public virtual Notice Notice { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}