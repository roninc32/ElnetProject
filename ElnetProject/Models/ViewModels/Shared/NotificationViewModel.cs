namespace ElnetProject.Models.ViewModels.Shared
{
    /// <summary>
    /// Standardized notification system for consistent messaging across the application
    /// Created by: roninc32
    /// Created on: 2025-03-30
    /// </summary>
    public class NotificationViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        // Notification type with standard options
        public NotificationType Type { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ExpiresAt { get; set; }
        public bool IsRead { get; set; }
        public string ActionUrl { get; set; }
        public string ActionText { get; set; }
        public string Icon { get; set; }
        public bool RequiresAction { get; set; }
        public string Category { get; set; }
        public int Priority { get; set; } // 1-5, where 1 is highest

        public enum NotificationType
        {
            Success,
            Error,
            Warning,
            Info
        }

        // Helper method for creating common notifications
        public static NotificationViewModel CreateAlert(
            string message,
            NotificationType type = NotificationType.Info,
            int priority = 3)
        {
            return new NotificationViewModel
            {
                Id = Guid.NewGuid().ToString(),
                Message = message,
                Type = type,
                Priority = priority
            };
        }
    }
}