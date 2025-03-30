using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;
using ElnetProject.Models.Domain.User;

namespace ElnetProject.Models.Domain.Communication
{
    public class Message : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SenderId { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        [Required]
        [StringLength(200)]
        public string Subject { get; set; }

        [Required]
        public string Content { get; set; }

        [StringLength(50)]
        public string MessageType { get; set; } = "Standard"; // Standard, Support, Complaint, Inquiry

        public int? ParentMessageId { get; set; }

        public bool IsRead { get; set; }

        public DateTime? ReadAt { get; set; }

        public bool IsFlagged { get; set; }

        public bool IsArchived { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Sent"; // Draft, Sent, Delivered, Failed

        public string? AttachmentUrl { get; set; }

        public bool RequiresResponse { get; set; }

        public DateTime? ResponseDeadline { get; set; }

        // Navigation properties
        [ForeignKey("SenderId")]
        public virtual ApplicationUser Sender { get; set; }

        [ForeignKey("ReceiverId")]
        public virtual ApplicationUser Receiver { get; set; }

        [ForeignKey("ParentMessageId")]
        public virtual Message ParentMessage { get; set; }

        public virtual ICollection<Message> Replies { get; set; }
    }
}