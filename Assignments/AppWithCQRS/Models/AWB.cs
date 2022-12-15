using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWithCQRS.Models
{
    public class AWB
    {
        [Key]
        public int AWBNumber { get; set; }

        public string Status_Type { get; set; }

        public string Sender { get; set; }

        public string Reciever { get; set; }
        
    }
}
