using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class CartTable
    {
        [Key]
        public int CartID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int UserID { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
