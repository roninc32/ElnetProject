using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;
using ElnetProject.Models.Domain.User;

namespace ElnetProject.Models.Domain.Document
{
    public class DocumentAccess : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DocumentId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string AccessType { get; set; } // View, Download, Edit, Delete, Admin

        public DateTime? AccessGrantedDate { get; set; }

        public DateTime? AccessExpiryDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Active"; // Active, Revoked, Expired

        public bool CanShare { get; set; }

        public DateTime? LastAccessedDate { get; set; }

        public int AccessCount { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        public bool HasAcknowledged { get; set; }

        public DateTime? AcknowledgedDate { get; set; }

        [StringLength(500)]
        public string? AcknowledgementComments { get; set; }

        // For delegated access
        public int? GrantedByAccessId { get; set; }

        [StringLength(500)]
        public string? GrantReason { get; set; }

        // Navigation properties
        [ForeignKey("DocumentId")]
        public virtual Document Document { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("GrantedByAccessId")]
        public virtual DocumentAccess GrantedByAccess { get; set; }

        public virtual ICollection<DocumentAccess> DelegatedAccesses { get; set; }

        // Access history tracking
        public virtual ICollection<DocumentAccessLog> AccessLogs { get; set; }
    }

    public class DocumentAccessLog
    {
        [Key]
        public int Id { get; set; }

        public int DocumentAccessId { get; set; }

        [Required]
        [StringLength(50)]
        public string ActionType { get; set; } // View, Download, Print, Share

        public DateTime ActionDate { get; set; }

        [StringLength(100)]
        public string? IpAddress { get; set; }

        [StringLength(200)]
        public string? UserAgent { get; set; }

        [ForeignKey("DocumentAccessId")]
        public virtual DocumentAccess DocumentAccess { get; set; }
    }
}