using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace final_project.Models
{
    public class User
    {
        [Key]
        public int user_Id { get; set; }
        [Required(ErrorMessage ="please enter Email")]
        [RegularExpression("/(^$|^.*@.*\\..*$)/" , ErrorMessage = "please enter a valid email") ]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
        //[RegularExpression(@"^([a-zA-Z0-9@*#]{8,15})$", ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase      Alphabet, 1 Number and 1 Special Character")]
      
        public string Password { get; set; }
        

        
        public ICollection<result> results { get; set; }
        public ICollection<address> addresses { get; set; } 


    }
}
