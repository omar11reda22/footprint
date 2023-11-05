using System.ComponentModel.DataAnnotations;

namespace final_project.Models
{
    public class Country
    {
        [Key]
        public int Country_ID { get; set; }
        [Required]
        public string name { get; set; }
     

    }
}
