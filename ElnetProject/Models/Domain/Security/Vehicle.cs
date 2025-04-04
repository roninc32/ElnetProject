using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;
using ElnetProject.Models.Domain.User;

namespace ElnetProject.Models.Domain.Security
{
    public class Vehicle : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int HomeOwnerId { get; set; }

        [Required]
        [StringLength(20)]
        public string PlateNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Make { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(20)]
        public string Year { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; } // Car, SUV, Motorcycle, etc.

        [StringLength(100)]
        public string? StickerNumber { get; set; }

        public DateTime? StickerValidUntil { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Active"; // Active, Inactive, Pending

        [StringLength(500)]
        public string? Notes { get; set; }

        // Navigation property
        [ForeignKey("HomeOwnerId")]
        public virtual HomeOwner HomeOwner { get; set; }
    }
}