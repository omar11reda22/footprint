using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace final_project.Models
{
    public class question
    {
        [Key]
        public int Question_ID { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public double factor { get; set; }
        [ForeignKey("Category")]
        public int Cat_ID { get; set; }
      
    }
}
