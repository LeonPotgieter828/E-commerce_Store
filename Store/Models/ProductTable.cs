using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class ProductTable
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        public byte[] ProductImg { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }   
    }
}
