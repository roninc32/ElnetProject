using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;
using ElnetProject.Models.Domain.User;

namespace ElnetProject.Models.Domain.Forum
{
    public class ForumAttachment : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public int? TopicId { get; set; }

        public int? ReplyId { get; set; }

        [Required]
        public string UploaderId { get; set; }

        [Required]
        [StringLength(255)]
        public string FileName { get; set; }

        [Required]
        [StringLength(100)]
        public string FileType { get; set; }

        [Required]
        [StringLength(500)]
        public string FilePath { get; set; }

        public long FileSize { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public int DownloadCount { get; set; }

        // Navigation properties
        [ForeignKey("TopicId")]
        public virtual ForumTopic Topic { get; set; }

        [ForeignKey("ReplyId")]
        public virtual ForumReply Reply { get; set; }

        [ForeignKey("UploaderId")]
        public virtual ApplicationUser Uploader { get; set; }
    }
}