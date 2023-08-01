using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace First_Project.DAL.Entities
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string DepartmentName { get; set; } = string.Empty;

        [StringLength(20)]
        public string DepartmentCode { get; set; } = string.Empty;

        public virtual ICollection<Student> Student { get; set; }
    }
}
