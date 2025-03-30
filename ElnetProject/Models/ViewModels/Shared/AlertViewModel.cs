namespace ElnetProject.Models.ViewModels.Shared
{
    /// <summary>
    /// Represents temporary alert messages for user feedback
    /// </summary>
    public class AlertViewModel
    {
        public string Message { get; set; }
        public AlertType Type { get; set; }
        public bool Dismissible { get; set; } = true;
        public int AutoDismissSeconds { get; set; } = 0; // 0 means no auto-dismiss
        public string Icon { get; set; }

        public enum AlertType
        {
            Success,
            Danger,
            Warning,
            Info
        }

        // Helper methods for creating common alerts
        public static AlertViewModel Success(string message, bool dismissible = true)
            => new AlertViewModel { Message = message, Type = AlertType.Success, Dismissible = dismissible, Icon = "fas fa-check-circle" };

        public static AlertViewModel Error(string message, bool dismissible = true)
            => new AlertViewModel { Message = message, Type = AlertType.Danger, Dismissible = dismissible, Icon = "fas fa-exclamation-circle" };
    }
}