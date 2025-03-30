using System.ComponentModel.DataAnnotations;

namespace ElnetProject.Models.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }

        // HomeOwner specific fields
        [Required(ErrorMessage = "Unit number is required")]
        [Display(Name = "Unit Number")]
        public string UnitNumber { get; set; }

        [Required(ErrorMessage = "Block number is required")]
        [Display(Name = "Block Number")]
        public string BlockNumber { get; set; }

        // Optional fields
        [Display(Name = "Emergency Contact Name")]
        public string EmergencyContactName { get; set; }

        [Display(Name = "Emergency Contact Phone")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string EmergencyContactPhone { get; set; }
    }
}