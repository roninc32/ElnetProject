using System.ComponentModel.DataAnnotations;

namespace ElnetProject.Models.ViewModels.Account
{
    public class ProfileViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "User Type")]
        public string UserType { get; set; }  // "Staff", "HomeOwner", "Admin"

        [Display(Name = "Account Created")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Last Login")]
        public DateTime? LastLogin { get; set; }

        // Common emergency contact information
        [Display(Name = "Emergency Contact Name")]
        public string EmergencyContactName { get; set; }

        [Display(Name = "Emergency Contact Phone")]
        public string EmergencyContactPhone { get; set; }

        // HomeOwner specific properties
        [Display(Name = "Unit Number")]
        public string UnitNumber { get; set; }

        [Display(Name = "Block Number")]
        public string BlockNumber { get; set; }

        // Staff specific properties
        [Display(Name = "Department")]
        public string Department { get; set; }

        [Display(Name = "Position")]
        public string Position { get; set; }

        // Profile Status
        [Display(Name = "Account Status")]
        public bool IsActive { get; set; }

        // Profile completeness indicator
        public int ProfileCompletenessPercentage
        {
            get
            {
                int completeness = 0;
                int totalFields = 0;

                // Count basic fields
                if (!string.IsNullOrEmpty(FirstName)) completeness++;
                if (!string.IsNullOrEmpty(LastName)) completeness++;
                if (!string.IsNullOrEmpty(PhoneNumber)) completeness++;
                if (!string.IsNullOrEmpty(EmergencyContactName)) completeness++;
                if (!string.IsNullOrEmpty(EmergencyContactPhone)) completeness++;
                totalFields = 5;

                // Add user type specific fields
                if (UserType == "HomeOwner")
                {
                    if (!string.IsNullOrEmpty(UnitNumber)) completeness++;
                    if (!string.IsNullOrEmpty(BlockNumber)) completeness++;
                    totalFields += 2;
                }
                else if (UserType == "Staff")
                {
                    if (!string.IsNullOrEmpty(Department)) completeness++;
                    if (!string.IsNullOrEmpty(Position)) completeness++;
                    totalFields += 2;
                }

                return (int)((float)completeness / totalFields * 100);
            }
        }

        // Helper property for full name
        public string FullName => $"{FirstName} {LastName}";

        // Helper property for address (for HomeOwners)
        public string FullAddress => UserType == "HomeOwner"
            ? $"Block {BlockNumber}, Unit {UnitNumber}"
            : string.Empty;

        // Helper property for staff info
        public string StaffInfo => UserType == "Staff"
            ? $"{Position} - {Department}"
            : string.Empty;
    }
}