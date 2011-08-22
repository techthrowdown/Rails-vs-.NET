using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProductDevelopment.Web.Models
{
    public class UserInputModel
    {
        [Required]
        [StringLength(20, MinimumLength = 4)]
        [Remote("ValidateUser", "Users", ErrorMessage = "Username is already taken, please choose another")]
        public string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Password { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string PasswordConfirm { get; set; }

        [Required]
        public bool Admin { get; set; }
    }
}