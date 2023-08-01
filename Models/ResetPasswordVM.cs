using System.ComponentModel.DataAnnotations;

namespace First_Project.Models
{
    public class ResetPasswordVM
    {
        [Required(ErrorMessage = "Mail Required")]
        [EmailAddress(ErrorMessage = "You Must Enter Vaild Mail")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Min Len 3")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Min Len 3")]
        [Compare("Password", ErrorMessage = "Not Matching")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;
    }
}
