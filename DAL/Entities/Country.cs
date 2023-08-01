using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace First_Project.DAL.Entities
{
    [Table("Country")]
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string CountryName { get; set; }

        public virtual ICollection<City> City { get; set; }
    }
}
