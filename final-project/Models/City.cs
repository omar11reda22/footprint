using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace final_project.Models
{
    public class City
    {
        [Key]
        public int City_ID { get; set; }
        [Required]
        public string name { get; set; }
        [ForeignKey("Governorate")]
        public int G_ID { get; set; }


    }
}