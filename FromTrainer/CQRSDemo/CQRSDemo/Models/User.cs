using System.ComponentModel.DataAnnotations;

namespace CQRSDemo.Models
{
    public class User
    {

        [Key]
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }

    }
}
