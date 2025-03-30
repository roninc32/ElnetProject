using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;
using ElnetProject.Models.Domain.User;

namespace ElnetProject.Models.Domain.Poll
{
    public class PollVote : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PollId { get; set; }

        public int? PollOptionId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? RatingValue { get; set; }

        [StringLength(500)]
        public string? Comment { get; set; }

        [StringLength(50)]
        public string VoteType { get; set; } = "Option"; // Option, Rating

        public DateTime VotedAt { get; set; }

        [StringLength(100)]
        public string? IpAddress { get; set; }

        [StringLength(200)]
        public string? UserAgent { get; set; }

        public bool IsValid { get; set; } = true;

        [StringLength(500)]
        public string? InvalidationReason { get; set; }

        public DateTime? InvalidatedAt { get; set; }

        public string? InvalidatedBy { get; set; }

        // For multi-choice polls
        public string? SelectedOptions { get; set; } // Comma-separated option IDs

        // Navigation properties
        [ForeignKey("PollId")]
        public virtual Poll Poll { get; set; }

        [ForeignKey("PollOptionId")]
        public virtual PollOption PollOption { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}