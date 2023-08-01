using First_Project.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace First_Project.DAL.Entities
{
    [Table("City")]
    public class City
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string CityName { get; set; }
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        public virtual ICollection<District> District { get; set; }
    }
}
