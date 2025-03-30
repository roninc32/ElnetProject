using System.ComponentModel.DataAnnotations;
using ElnetProject.Models.Domain.Base;

namespace ElnetProject.Models.Domain.Notice
{
    public class NoticeType : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }

        public bool RequiresAcknowledgement { get; set; }

        public bool RequiresApproval { get; set; }

        public int DefaultDurationDays { get; set; }

        [StringLength(50)]
        public string DefaultPriority { get; set; } = "Normal";

        public string DefaultTargetAudience { get; set; } // JSON array of default audience types

        public string Template { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Active"; // Active, Inactive, Archived

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(100)]
        public string Icon { get; set; }

        // Navigation property
        public virtual ICollection<Notice> Notices { get; set; }
    }
}