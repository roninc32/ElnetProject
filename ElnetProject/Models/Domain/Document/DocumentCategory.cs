using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;

namespace ElnetProject.Models.Domain.Document
{
    public class DocumentCategory : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int? ParentCategoryId { get; set; }

        [StringLength(50)]
        public string AccessLevel { get; set; } = "Public"; // Public, Restricted, Private

        public bool RequiresApproval { get; set; }

        public int RetentionPeriodDays { get; set; }

        public bool AutoArchive { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Active"; // Active, Archived, Hidden

        public int DisplayOrder { get; set; }

        [StringLength(100)]
        public string? Icon { get; set; }

        [StringLength(50)]
        public string? Color { get; set; }

        // Navigation properties
        [ForeignKey("ParentCategoryId")]
        public virtual DocumentCategory ParentCategory { get; set; }
        public virtual ICollection<DocumentCategory> SubCategories { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}