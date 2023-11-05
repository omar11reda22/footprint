using System.ComponentModel.DataAnnotations;

namespace final_project.Models
{
    public class Category
    {
        [Key]
        public int Cat_ID { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string name { get; set; }
    }
}
