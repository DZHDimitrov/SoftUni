using System.ComponentModel.DataAnnotations;

namespace SharedTrip.ViewModels
{
    public class RegisterViewModel
    {
        [StringLength(20,MinimumLength = 5,ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string UserName { get; set; }

        [StringLength(20,MinimumLength = 6,ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
    }
}
