using First_Project.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace First_Project.Models
{
    public class StudentVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter E-Mail")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter Phone")]
        [MaxLength(11, ErrorMessage = "Max len 11")]
        [MinLength(11, ErrorMessage = "Min Len 11")]
        public string Phone { get; set; } = string.Empty;

        public int Age { get; set; }

        [Required(ErrorMessage = "Enter Address")]
        [RegularExpression("[0-9]{2,5}-[a-zA-Z]{3,50}-[a-zA-Z]{3,50}-[a-zA-Z]{3,50}", ErrorMessage = "Enter Like 12-StreetName-CityName-CountryName")]
        public string Address { get; set; } = string.Empty;

        public float GPA { get; set; }

        public DateTime Start_Education { get; set; }

        public DateTime End_Education { get; set; }

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; } = string.Empty;

        public IFormFile PhotoUrl { get; set; }

        public string PhotoName { get; set; } = string.Empty;

        public IFormFile CvUrl { get; set; }

        public string CvName { get; set; } = string.Empty;

    }
}
