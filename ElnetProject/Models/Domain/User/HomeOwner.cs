using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;
using ElnetProject.Models.Domain.Billing;
using ElnetProject.Models.Domain.Security;
using ElnetProject.Models.Domain.Service;

namespace ElnetProject.Models.Domain.User
{
    public class HomeOwner : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        [Required]
        [StringLength(100)]
        public string PropertyAddress { get; set; }

        [StringLength(50)]
        public string? LotNumber { get; set; }

        [StringLength(50)]
        public string? BlockNumber { get; set; }

        public DateTime MoveInDate { get; set; }

        [StringLength(20)]
        public string ResidentType { get; set; } = "Owner"; // Owner, Tenant

        [StringLength(500)]
        public string? Notes { get; set; }

        // Navigation properties
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
    }
}