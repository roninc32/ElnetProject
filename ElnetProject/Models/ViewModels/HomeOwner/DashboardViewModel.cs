using ElnetProject.Models.Domain.Facility;
using ElnetProject.Models.Domain.Service;
using ElnetProject.Models.Domain.Billing;
using ElnetProject.Models.Domain.Event;
using ElnetProject.Models.Domain.Notice;
using ElnetProject.Models.Domain.Poll;
using ElnetProject.Models.Domain.Security;
using ElnetProject.Models.Domain.Document;

namespace ElnetProject.Models.ViewModels.HomeOwner
{
    public class DashboardViewModel
    {
        // User Information
        public string FullName { get; set; }
        public string UnitNumber { get; set; }
        public string BlockNumber { get; set; }
        public string ResidenceInfo => $"Block {BlockNumber}, Unit {UnitNumber}";

        // Billing Summary
        public BillingInfo BillingSummary { get; set; }
        public class BillingInfo
        {
            public decimal TotalOutstanding { get; set; }
            public int PendingBills { get; set; }
            public DateTime? NextDueDate { get; set; }
            public Bill LatestBill { get; set; }
            public List<Payment> RecentPayments { get; set; }
        }

        // Service Requests
        public ServiceRequestInfo ServiceRequests { get; set; }
        public class ServiceRequestInfo
        {
            public int TotalActive { get; set; }
            public int PendingRequests { get; set; }
            public int InProgressRequests { get; set; }
            public List<ServiceRequest> RecentRequests { get; set; }
        }

        // Facility Bookings
        public FacilityInfo FacilityBookings { get; set; }
        public class FacilityInfo
        {
            public int UpcomingReservations { get; set; }
            public List<FacilityReservation> RecentReservations { get; set; }
            public List<Facility> PopularFacilities { get; set; }
        }

        // Notifications
        public NotificationInfo Notifications { get; set; }
        public class NotificationInfo
        {
            public int UnreadCount { get; set; }
            public List<NotificationItem> RecentNotifications { get; set; }
        }

        public class NotificationItem
        {
            public string Title { get; set; }
            public string Message { get; set; }
            public DateTime CreatedAt { get; set; }
            public string Type { get; set; } // "Announcement", "Bill", "Service", "General"
            public bool IsRead { get; set; }
            public string Link { get; set; }
        }

        // Visitor Passes
        public VisitorInfo VisitorPasses { get; set; }
        public class VisitorInfo
        {
            public int ActivePasses { get; set; }
            public int PendingRequests { get; set; }
            public List<VisitorPass> UpcomingVisits { get; set; }
        }

        // Quick Links
        public List<QuickLink> QuickLinks { get; set; }
        public class QuickLink
        {
            public string Title { get; set; }
            public string Url { get; set; }
            public string Icon { get; set; }
            public string Description { get; set; }
        }

        // Community Updates
        public CommunityInfo CommunityUpdates { get; set; }
        public class CommunityInfo
        {
            public List<Event> UpcomingEvents { get; set; }
            public List<Notice> RecentNotices { get; set; }
            public List<Poll> ActivePolls { get; set; }
        }

        // Documents
        public DocumentInfo Documents { get; set; }
        public class DocumentInfo
        {
            public int NewDocuments { get; set; }
            public List<Document> RecentDocuments { get; set; }
        }

        // Maintenance Schedule
        public MaintenanceInfo MaintenanceSchedule { get; set; }
        public class MaintenanceInfo
        {
            public DateTime? NextScheduledMaintenance { get; set; }
            public string MaintenanceType { get; set; }
            public string Description { get; set; }
            public List<MaintenanceScheduleItem> UpcomingMaintenance { get; set; }
        }

        public class MaintenanceScheduleItem
        {
            public DateTime ScheduledDate { get; set; }
            public string Type { get; set; }
            public string Location { get; set; }
            public string Status { get; set; }
        }
    }
}