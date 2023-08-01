using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace First_Project.DAL.Entities
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Address { get; set; } = string.Empty;

        public float GPA { get; set; }

        public DateTime Start_Education { get; set; }

        public DateTime End_Education { get; set; }

        public string PhotoName { get; set; } 

        public string CvName { get; set; } 

        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}
