using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;
using ElnetProject.Models.Domain.User;

namespace ElnetProject.Models.Domain.Forum
{
    public class ForumReply : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TopicId { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [Required]
        public string Content { get; set; }

        public bool IsAnswer { get; set; }

        public int? ParentReplyId { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Active"; // Active, Hidden, Deleted

        public int LikeCount { get; set; }

        public bool IsEdited { get; set; }

        [StringLength(500)]
        public string? EditReason { get; set; }

        // Navigation properties
        [ForeignKey("TopicId")]
        public virtual ForumTopic Topic { get; set; }

        [ForeignKey("AuthorId")]
        public virtual ApplicationUser Author { get; set; }

        [ForeignKey("ParentReplyId")]
        public virtual ForumReply ParentReply { get; set; }

        public virtual ICollection<ForumReply> ChildReplies { get; set; }
        public virtual ICollection<ForumAttachment> Attachments { get; set; }
    }
}