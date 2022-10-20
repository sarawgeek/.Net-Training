using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWithCQRS.Models
{
    public class AWB
    {
        [Key]
        public int AWBNumber { get; set; }

        [ForeignKey("StatusTypes")]
        public StatusTypes Status { get; set; }

        public string Sender { get; set; }

        public string Reciever { get; set; }
        
        //public ICollection<StatusTypes> StatusTypes { get; set; }

        /*public AWB(int AWBNumber, string Status, string Sender, string Reciever)
        {
            this.AWBNumber = AWBNumber;
            this.Status = Status;
            this.Sender = Sender;
            this.Reciever = Reciever;
        }*/
    }
}
