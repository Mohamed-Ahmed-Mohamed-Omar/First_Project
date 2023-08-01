using System.ComponentModel.DataAnnotations;

namespace First_Project.Models
{
    public class CreateRoleVM
    {
        [Required(ErrorMessage = "Role Name Required")]
        public string RoleName { get; set; } = string.Empty;
    }
}
