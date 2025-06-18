using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class UserTable
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }    
    }
}
