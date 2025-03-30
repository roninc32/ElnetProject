using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;
using ElnetProject.Models.Domain.User;

namespace ElnetProject.Models.Domain.Poll
{
    public class Poll : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CreatorId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Draft"; // Draft, Active, Closed, Archived

        [StringLength(50)]
        public string PollType { get; set; } = "SingleChoice"; // SingleChoice, MultipleChoice, Rating

        public bool IsAnonymous { get; set; }

        public bool ShowResultsBeforeEnd { get; set; }

        public bool RequireAuthentication { get; set; } = true;

        [StringLength(50)]
        public string AccessLevel { get; set; } = "All"; // All, Residents, Staff, Board

        public int? MaxChoicesPerUser { get; set; }

        public int? MinChoicesRequired { get; set; }

        public bool AllowComments { get; set; }

        public bool NotifyOnVote { get; set; }

        [StringLength(500)]
        public string? TargetAudience { get; set; }

        public string? AttachmentUrls { get; set; }

        [StringLength(500)]
        public string? ResultSummary { get; set; }

        public int TotalVotes { get; set; }

        public int UniqueVoters { get; set; }

        // Navigation properties
        [ForeignKey("CreatorId")]
        public virtual ApplicationUser Creator { get; set; }
        public virtual ICollection<PollOption> Options { get; set; }
        public virtual ICollection<PollVote> Votes { get; set; }
        public virtual ICollection<PollComment> Comments { get; set; }
    }

    public class PollComment : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public int PollId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Content { get; set; }

        public int? ParentCommentId { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Active"; // Active, Hidden, Deleted

        // Navigation properties
        [ForeignKey("PollId")]
        public virtual Poll Poll { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("ParentCommentId")]
        public virtual PollComment ParentComment { get; set; }

        public virtual ICollection<PollComment> Replies { get; set; }
    }
}