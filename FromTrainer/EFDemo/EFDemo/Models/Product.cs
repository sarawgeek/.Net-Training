using System.ComponentModel.DataAnnotations;

namespace EFDemo.Models
{
    
    public class Product
    {

        [Key]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }
        public string Category { get; set; }

    }
}
