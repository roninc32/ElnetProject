using ElnetProject.Models.Domain.User;

namespace ElnetProject.Models.ViewModels.Admin
{
    public class DashboardViewModel
    {
        // User Statistics
        public int TotalUsers { get; set; }
        public int TotalHomeOwners { get; set; }
        public int TotalStaff { get; set; }
        public int NewUsersThisMonth { get; set; }

        // Facility Statistics
        public int TotalFacilities { get; set; }
        public int ActiveReservations { get; set; }
        public int PendingReservations { get; set; }

        // Service Request Statistics
        public int TotalServiceRequests { get; set; }
        public int PendingServiceRequests { get; set; }
        public int InProgressServiceRequests { get; set; }
        public int CompletedServiceRequests { get; set; }

        // Security Statistics
        public int ActiveVisitorPasses { get; set; }
        public int RegisteredVehicles { get; set; }

        // Communication Statistics
        public int TotalAnnouncements { get; set; }
        public int UnreadMessages { get; set; }

        // Billing Statistics
        public int PendingPayments { get; set; }
        public decimal TotalPaymentsThisMonth { get; set; }
        public int OverduePayments { get; set; }

        // Recent Activity Lists
        public List<RecentActivity> RecentActivities { get; set; }
        public List<Alert> SystemAlerts { get; set; }

        public class RecentActivity
        {
            public DateTime Timestamp { get; set; }
            public string ActivityType { get; set; }
            public string Description { get; set; }
            public string UserName { get; set; }
            public string Status { get; set; }
        }

        public class Alert
        {
            public string Type { get; set; } // "Warning", "Error", "Info"
            public string Message { get; set; }
            public DateTime Timestamp { get; set; }
            public bool IsResolved { get; set; }
        }

        // Chart Data
        public Dictionary<string, int> UserRegistrationTrend { get; set; }
        public Dictionary<string, decimal> MonthlyRevenue { get; set; }
        public Dictionary<string, int> ServiceRequestsByType { get; set; }
    }
}