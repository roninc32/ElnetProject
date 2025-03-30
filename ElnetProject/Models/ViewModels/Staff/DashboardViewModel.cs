using ElnetProject.Models.Domain.Service;
using ElnetProject.Models.Domain.Facility;
using ElnetProject.Models.Domain.Security;
using System;
using System.Collections.Generic;

namespace ElnetProject.Models.ViewModels.Staff
{
    public class DashboardViewModel
    {
        // Define MaintenanceTask class inside FacilityManagementInfo
        public class MaintenanceTask
        {
            public int Id { get; set; }
            public DateTime ScheduledDate { get; set; }
            public string TaskType { get; set; }
            public string Description { get; set; }
            public string Location { get; set; }
            public string Status { get; set; }
            public string AssignedTo { get; set; }
            public string Priority { get; set; }
        }

        // Staff Information
        public string StaffId { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public DateTime CurrentShift { get; set; }

        // Task Management
        public TaskSummary Tasks { get; set; }
        public class TaskSummary
        {
            public int TotalAssigned { get; set; }
            public int PendingTasks { get; set; }
            public int InProgressTasks { get; set; }
            public int CompletedToday { get; set; }
            public List<ServiceRequest> UrgentRequests { get; set; }
            public List<ServiceRequest> TodaysTasks { get; set; }
        }

        // Service Request Management
        public ServiceRequestSummary ServiceRequests { get; set; }
        public class ServiceRequestSummary
        {
            public int NewRequests { get; set; }
            public int InProgress { get; set; }
            public int PendingReview { get; set; }
            public int CompletedToday { get; set; }
            public List<ServiceRequest> RecentRequests { get; set; }
            public Dictionary<string, int> RequestsByType { get; set; }
            public Dictionary<string, int> RequestsByStatus { get; set; }
        }

        // Facility Management
        public FacilityManagementInfo FacilityManagement { get; set; }
        public class FacilityManagementInfo
        {
            public int TotalFacilities { get; set; }
            public int FacilitiesNeedingAttention { get; set; }
            public List<FacilityReservation> TodaysReservations { get; set; }
            public List<MaintenanceTask> ScheduledMaintenance { get; set; }
        }

        // Visitor Management
        public VisitorManagementInfo VisitorManagement { get; set; }
        public class VisitorManagementInfo
        {
            public int ExpectedVisitors { get; set; }
            public int PendingApprovals { get; set; }
            public List<VisitorPass> TodaysVisitors { get; set; }
        }

        // Work Schedule
        public ScheduleInfo Schedule { get; set; }
        public class ScheduleInfo
        {
            public DateTime ShiftStart { get; set; }
            public DateTime ShiftEnd { get; set; }
            public List<ScheduledTask> UpcomingTasks { get; set; }
            public List<Meeting> ScheduledMeetings { get; set; }
        }

        public class ScheduledTask
        {
            public DateTime ScheduledTime { get; set; }
            public string TaskType { get; set; }
            public string Location { get; set; }
            public string Description { get; set; }
            public string Priority { get; set; }
        }

        public class Meeting
        {
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string Title { get; set; }
            public string Location { get; set; }
            public List<string> Attendees { get; set; }
        }

        // Performance Metrics
        public PerformanceMetrics Performance { get; set; }
        public class PerformanceMetrics
        {
            public int TasksCompletedThisWeek { get; set; }
            public double AverageResponseTime { get; set; }
            public double ResolutionRate { get; set; }
            public int PositiveFeedbacks { get; set; }
        }

        // Notifications
        public List<StaffNotification> Notifications { get; set; }
        public class StaffNotification
        {
            public string Title { get; set; }
            public string Message { get; set; }
            public DateTime Timestamp { get; set; }
            public string Priority { get; set; }
            public string Type { get; set; }
            public bool IsRead { get; set; }
            public string RelatedTaskId { get; set; }
        }

        // Quick Actions
        public List<QuickAction> QuickActions { get; set; }
        public class QuickAction
        {
            public string ActionName { get; set; }
            public string Icon { get; set; }
            public string Route { get; set; }
            public string Description { get; set; }
        }

        // System Status
        public SystemStatus Status { get; set; }
        public class SystemStatus
        {
            public bool IsMaintenance { get; set; }
            public List<string> ActiveAlerts { get; set; }
            public Dictionary<string, string> SystemStatuses { get; set; }
        }
    }
}