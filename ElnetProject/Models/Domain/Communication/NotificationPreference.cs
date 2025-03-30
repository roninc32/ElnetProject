using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElnetProject.Models.Domain.Base;
using ElnetProject.Models.Domain.User;

namespace ElnetProject.Models.Domain.Communication
{
    public class NotificationPreference : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        // Email Notifications
        public bool EmailAnnouncements { get; set; } = true;
        public bool EmailMessages { get; set; } = true;
        public bool EmailBilling { get; set; } = true;
        public bool EmailMaintenance { get; set; } = true;
        public bool EmailEvents { get; set; } = true;
        public bool EmailSecurity { get; set; } = true;

        // SMS Notifications
        public bool SmsAnnouncements { get; set; } = false;
        public bool SmsEmergency { get; set; } = true;
        public bool SmsMaintenance { get; set; } = false;
        public bool SmsSecurity { get; set; } = true;

        // Push Notifications
        public bool PushAnnouncements { get; set; } = true;
        public bool PushMessages { get; set; } = true;
        public bool PushBilling { get; set; } = false;
        public bool PushMaintenance { get; set; } = true;
        public bool PushEvents { get; set; } = true;
        public bool PushSecurity { get; set; } = true;

        // Notification Schedule
        public bool QuietHoursEnabled { get; set; }
        public TimeSpan? QuietHoursStart { get; set; }
        public TimeSpan? QuietHoursEnd { get; set; }

        [StringLength(50)]
        public string PreferredLanguage { get; set; } = "English";

        [StringLength(20)]
        public string TimeZone { get; set; } = "UTC";

        // Frequency settings
        [StringLength(50)]
        public string DigestFrequency { get; set; } = "Daily"; // Instant, Daily, Weekly

        // Navigation property
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}