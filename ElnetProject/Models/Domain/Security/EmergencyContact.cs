using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;
using ElnetProject.Models.Domain.User;

namespace ElnetProject.Models.Domain.Security
{
    public class EmergencyContact : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string HomeOwnerId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Relationship { get; set; }

        [Required]
        [Phone]
        [StringLength(20)]
        public string PrimaryPhone { get; set; }

        [Phone]
        [StringLength(20)]
        public string? SecondaryPhone { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        public bool IsPrimaryContact { get; set; }

        [StringLength(50)]
        public string PreferredContactMethod { get; set; } = "Phone"; // Phone, Email, SMS

        public bool HasAccessRights { get; set; }

        [StringLength(500)]
        public string? MedicalNotes { get; set; }

        [StringLength(500)]
        public string? SpecialInstructions { get; set; }

        // Navigation property
        [ForeignKey("HomeOwnerId")]
        public virtual HomeOwner HomeOwner { get; set; }
    }
}