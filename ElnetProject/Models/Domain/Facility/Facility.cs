using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;

namespace ElnetProject.Models.Domain.Facility
{
    public class Facility : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public int FacilityTypeId { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal HourlyRate { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        public TimeSpan OpeningTime { get; set; }

        [Required]
        public TimeSpan ClosingTime { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Available";

        [StringLength(500)]
        public string? MaintenanceNotes { get; set; }

        // Navigation properties
        [ForeignKey("FacilityTypeId")]
        public virtual FacilityType FacilityType { get; set; }
        public virtual ICollection<FacilityReservation> Reservations { get; set; }
    }
}