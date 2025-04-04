using System.ComponentModel.DataAnnotations;

namespace ElnetProject.Models.Domain.Base
{
    public abstract class BaseEntity
    {
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [StringLength(100)]
        public string? UpdatedBy { get; set; }

        public bool IsActive { get; set; } = true;
    }
}