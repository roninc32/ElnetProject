using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;
using ElnetProject.Models.Domain.User;

namespace ElnetProject.Models.Domain.Service
{
    public class ServiceRequest : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int HomeOwnerId { get; set; }

        [Required]
        public int ServiceTypeId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Priority { get; set; } = "Normal"; // Low, Normal, High, Emergency

        [StringLength(50)]
        public string Status { get; set; } = "Pending"; // Pending, Assigned, InProgress, Completed, Cancelled

        public int? AssignedToId { get; set; }

        public DateTime? PreferredDate { get; set; }

        public TimeSpan? PreferredTime { get; set; }

        [StringLength(200)]
        public string? Location { get; set; }

        public bool RequiresEntry { get; set; }

        public DateTime? ScheduledDate { get; set; }

        public TimeSpan? ScheduledTime { get; set; }

        public DateTime? CompletedDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? EstimatedCost { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? ActualCost { get; set; }

        public int? Rating { get; set; }

        [StringLength(500)]
        public string? Feedback { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        public string? AttachmentUrls { get; set; }

        // Navigation properties
        [ForeignKey("HomeOwnerId")]
        public virtual HomeOwner HomeOwner { get; set; }

        [ForeignKey("ServiceTypeId")]
        public virtual ServiceType ServiceType { get; set; }

        [ForeignKey("AssignedToId")]
        public virtual Staff AssignedTo { get; set; }

        public virtual ICollection<ServiceRequestUpdate> Updates { get; set; }
    }
}