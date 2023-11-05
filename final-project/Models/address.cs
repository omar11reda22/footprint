using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace final_project.Models
{
    public class address
    {
        [Key]
        public int address_ID { get; set; }
        [ForeignKey("User")]
        public int useruser_ID { get; set; }
        [ForeignKey("City")]
        public int city_ID { get; set; }
        [ForeignKey("Country")]
        public int country_ID { get; set; }
        [ForeignKey("Governorate")]
        public int governorate_ID { get; set; }
    }
}
