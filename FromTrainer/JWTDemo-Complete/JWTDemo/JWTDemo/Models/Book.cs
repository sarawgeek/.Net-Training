using System.ComponentModel.DataAnnotations;

namespace JWTDemo.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Author { get; set; }
        public int Cost { get; set; }
    }
}
