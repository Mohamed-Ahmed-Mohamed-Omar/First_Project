using System.ComponentModel.DataAnnotations;

namespace First_Project.Models
{
    public class ForgetPasswordVM
    {
        [EmailAddress(ErrorMessage = "Required Email")]
        public string Email { get; set; } = string.Empty;

    }
}
