using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace First_Project.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Mail Required")]
        [EmailAddress(ErrorMessage = "You Must Enter Vaild Mail")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Min Len 3")]
        public string Password { get; set; } = string.Empty;
        public bool RemomberMe { get; set; }
        //public string ReturnUrl { get; set; }

        //// AuthenticationScheme is in Microsoft.AspNetCore.Authentication namespace
        //public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
