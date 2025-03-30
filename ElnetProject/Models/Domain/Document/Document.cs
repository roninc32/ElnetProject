using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;
using ElnetProject.Models.Domain.User;

namespace ElnetProject.Models.Domain.Document
{
    public class Document : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string UploaderId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        public string FileName { get; set; }

        [Required]
        [StringLength(100)]
        public string FileType { get; set; }

        [Required]
        [StringLength(500)]
        public string FilePath { get; set; }

        public long FileSize { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Active"; // Active, Archived, UnderReview

        [StringLength(100)]
        public string Version { get; set; } = "1.0";

        public int? ParentDocumentId { get; set; }

        public bool IsPublic { get; set; }

        public bool RequiresAcknowledgement { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public int ViewCount { get; set; }

        public int DownloadCount { get; set; }

        [StringLength(500)]
        public string? Tags { get; set; }

        public string? MetaData { get; set; }

        // Navigation properties
        [ForeignKey("CategoryId")]
        public virtual DocumentCategory Category { get; set; }

        [ForeignKey("UploaderId")]
        public virtual ApplicationUser Uploader { get; set; }

        [ForeignKey("ParentDocumentId")]
        public virtual Document ParentDocument { get; set; }

        public virtual ICollection<Document> Versions { get; set; }
        public virtual ICollection<DocumentAccess> AccessRights { get; set; }
    }
}