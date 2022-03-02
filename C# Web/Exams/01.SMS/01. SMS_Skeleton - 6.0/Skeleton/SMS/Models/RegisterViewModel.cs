using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class RegisterViewModel
    {
        [StringLength(20,MinimumLength = 5,ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [StringLength(20,MinimumLength = 6,ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
