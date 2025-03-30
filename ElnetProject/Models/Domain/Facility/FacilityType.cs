using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;

namespace ElnetProject.Models.Domain.Facility
{
    public class FacilityType : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DefaultRate { get; set; }

        public bool RequiresApproval { get; set; }

        // Navigation property
        public virtual ICollection<Facility> Facilities { get; set; }
    }
}