using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace First_Project.DAL.Entities
{
    [Table("District")]
    public class District
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string DistrictName { get; set; }
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }
    }
}
