using System.ComponentModel.DataAnnotations;

namespace First_Project.Models
{
    public class DepartmentVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Department Name")]
        [MinLength(2, ErrorMessage = "Min Len 2")]
        [MaxLength(10, ErrorMessage = "Max Len 10")]
        public string DepartmentName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter Department Code")]
        public string DepartmentCode { get; set; } = string.Empty;
    }
}
