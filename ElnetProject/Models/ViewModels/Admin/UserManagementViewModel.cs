using System.ComponentModel.DataAnnotations;

namespace ElnetProject.Models.ViewModels.Admin
{
    public class UserManagementViewModel
    {
        // List of users with pagination
        public List<UserListItem> Users { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalUsers { get; set; }
        public int PageSize { get; set; }

        // Filtering options
        public string SearchTerm { get; set; }
        public string UserType { get; set; } // "All", "HomeOwner", "Staff"
        public string SortBy { get; set; }
        public bool SortAscending { get; set; }
        public string StatusFilter { get; set; } // "All", "Active", "Inactive"

        // Bulk actions
        public List<string> SelectedUsers { get; set; }
        public string BulkAction { get; set; } // "Activate", "Deactivate", "Delete"

        public class UserListItem
        {
            public string Id { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string FullName => $"{FirstName} {LastName}";
            public string UserType { get; set; }
            public string PhoneNumber { get; set; }
            public bool IsActive { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime? LastLogin { get; set; }

            // HomeOwner specific
            public string UnitNumber { get; set; }
            public string BlockNumber { get; set; }

            // Staff specific
            public string Department { get; set; }
            public string Position { get; set; }

            // Statistics
            public int TotalServiceRequests { get; set; }
            public int PendingPayments { get; set; }
            public bool HasActiveReservations { get; set; }
        }

        // Quick statistics
        public UserStatistics Statistics { get; set; }

        public class UserStatistics
        {
            public int TotalUsers { get; set; }
            public int ActiveUsers { get; set; }
            public int InactiveUsers { get; set; }
            public int NewUsersToday { get; set; }
            public Dictionary<string, int> UsersByType { get; set; }
        }
    }
}