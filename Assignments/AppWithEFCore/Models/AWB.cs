using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWithEFCore.Models
{
    public class AWB
    {
        [Key]
        public int AWBNumber { get; set; }

        //[ForeignKey("StatusTypes")]
        //public int Status_Type { get; set; }
        public string Status_Type { get; set; }

        public string Sender { get; set; }

        public string Reciever { get; set; }
        
    }
}
