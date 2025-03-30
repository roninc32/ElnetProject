using ElnetProject.Models.Domain.Communication;
using ElnetProject.Models.Domain.Service;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ElnetProject.Models.Domain.User
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? LastLogin { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual Admin? Admin { get; set; }
        public virtual Staff? Staff { get; set; }
        public virtual HomeOwner? HomeOwner { get; set; }
        public virtual ICollection<Message> SentMessages { get; set; }
        public virtual ICollection<Message> ReceivedMessages { get; set; }
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
        public virtual NotificationPreference NotificationPreference { get; set; }
    }
}