using System.ComponentModel.DataAnnotations;

namespace ElnetProject.Models.ViewModels.Account
{
    public class AdminCreateUserViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "User type is required")]
        public string UserType { get; set; } // "Staff" or "HomeOwner"

        // Additional fields for Staff
        [Display(Name = "Department")]
        public string Department { get; set; }

        [Display(Name = "Position")]
        public string Position { get; set; }

        // Additional fields for HomeOwner
        [Display(Name = "Unit Number")]
        public string UnitNumber { get; set; }

        [Display(Name = "Block Number")]
        public string BlockNumber { get; set; }
    }
}