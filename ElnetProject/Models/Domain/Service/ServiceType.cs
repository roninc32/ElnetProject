using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;

namespace ElnetProject.Models.Domain.Service
{
    public class ServiceType : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Category { get; set; } // Maintenance, Repair, Installation, etc.

        public bool RequiresApproval { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? StandardRate { get; set; }

        public int? EstimatedDuration { get; set; } // In minutes

        public bool IsUrgentAllowed { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? UrgentRate { get; set; }

        public string? RequiredSkills { get; set; }

        public string? RequiredEquipment { get; set; }

        public bool RequiresQuotation { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Active"; // Active, Inactive, Seasonal

        public TimeSpan? ServiceStartTime { get; set; }

        public TimeSpan? ServiceEndTime { get; set; }

        [StringLength(500)]
        public string? Terms { get; set; }

        // Navigation property
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
    }
}