using System.ComponentModel.DataAnnotations;
using ElnetProject.Models.Domain.Base;

namespace ElnetProject.Models.Domain.Forum
{
    public class ForumCategory : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int DisplayOrder { get; set; }

        public bool AllowAnonymousPosts { get; set; }

        [StringLength(50)]
        public string AccessLevel { get; set; } = "Public"; // Public, Residents, Staff, Admin

        // Navigation property
        public virtual ICollection<ForumTopic> Topics { get; set; }
    }
}