using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace final_project.Models
{
    public class Governorate
    {
        [Key]
        public int G_ID { get; set; }
        public string name { get; set; }
        [ForeignKey("Country")]
        public int Country_ID { get; set; }


    }
}