using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;

namespace ElnetProject.Models.Domain.User
{
    public class Admin : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Department { get; set; }

        [StringLength(100)]
        public string Position { get; set; }

        public DateTime HireDate { get; set; }

        [StringLength(500)]
        public string? AdminNotes { get; set; }

        // Navigation property
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}