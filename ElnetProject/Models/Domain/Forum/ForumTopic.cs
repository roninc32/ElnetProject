using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;
using ElnetProject.Models.Domain.User;

namespace ElnetProject.Models.Domain.Forum
{
    public class ForumTopic : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int ViewCount { get; set; }

        public bool IsPinned { get; set; }

        public bool IsLocked { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Active"; // Active, Closed, Hidden

        public DateTime? LastReplyAt { get; set; }

        public string? LastReplyById { get; set; }

        // Navigation properties
        [ForeignKey("CategoryId")]
        public virtual ForumCategory Category { get; set; }

        [ForeignKey("AuthorId")]
        public virtual ApplicationUser Author { get; set; }

        [ForeignKey("LastReplyById")]
        public virtual ApplicationUser LastReplyBy { get; set; }

        public virtual ICollection<ForumReply> Replies { get; set; }
        public virtual ICollection<ForumAttachment> Attachments { get; set; }
    }
}