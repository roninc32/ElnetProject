using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;

namespace ElnetProject.Models.Domain.Poll
{
    public class PollOption : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PollId { get; set; }

        [Required]
        [StringLength(200)]
        public string OptionText { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public int DisplayOrder { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? MinimumRating { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? MaximumRating { get; set; }

        public int VoteCount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? AverageRating { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Active"; // Active, Hidden, Deleted

        public string? MetaData { get; set; }

        // Navigation properties
        [ForeignKey("PollId")]
        public virtual Poll Poll { get; set; }
        public virtual ICollection<PollVote> Votes { get; set; }
    }
}