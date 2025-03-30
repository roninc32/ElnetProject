using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;
using ElnetProject.Models.Domain.User;

namespace ElnetProject.Models.Domain.Service
{
    public class ServiceRequestUpdate : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ServiceRequestId { get; set; }

        [Required]
        public string UpdatedById { get; set; }

        [Required]
        public string Content { get; set; }

        [StringLength(50)]
        public string UpdateType { get; set; } = "Status"; // Status, Comment, Assignment, Schedule

        [StringLength(50)]
        public string? OldStatus { get; set; }

        [StringLength(50)]
        public string? NewStatus { get; set; }

        public string? OldAssigneeId { get; set; }

        public string? NewAssigneeId { get; set; }

        public DateTime? OldScheduledDate { get; set; }

        public DateTime? NewScheduledDate { get; set; }

        public bool IsInternal { get; set; }

        public string? AttachmentUrls { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        public bool RequiresAcknowledgement { get; set; }

        public DateTime? AcknowledgedAt { get; set; }

        public string? AcknowledgedById { get; set; }

        // Navigation properties
        [ForeignKey("ServiceRequestId")]
        public virtual ServiceRequest ServiceRequest { get; set; }

        [ForeignKey("UpdatedById")]
        public virtual ApplicationUser UpdatedBy { get; set; }

        [ForeignKey("OldAssigneeId")]
        public virtual Staff OldAssignee { get; set; }

        [ForeignKey("NewAssigneeId")]
        public virtual Staff NewAssignee { get; set; }

        [ForeignKey("AcknowledgedById")]
        public virtual ApplicationUser AcknowledgedBy { get; set; }
    }
}