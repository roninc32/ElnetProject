using System.ComponentModel.DataAnnotations;

namespace ElnetProject.Models.ViewModels.Account
{
    public class EditProfileViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Emergency Contact Name")]
        public string EmergencyContactName { get; set; }

        [Display(Name = "Emergency Contact Phone")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string EmergencyContactPhone { get; set; }

        // For HomeOwners only
        [Display(Name = "Unit Number")]
        public string UnitNumber { get; set; }

        [Display(Name = "Block Number")]
        public string BlockNumber { get; set; }
    }
}