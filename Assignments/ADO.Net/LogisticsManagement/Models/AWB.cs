namespace LogisticsManagement.Models
{
    public class AWB
    {
        public int AWBNumber { get; set; }

        public string Status { get; set; }

        public string Sender { get; set; }

        public string Reciever { get; set; }

        public AWB(int AWBNumber, string Status, string Sender, string Reciever)
        {
            this.AWBNumber = AWBNumber;
            this.Status = Status;
            this.Sender = Sender;
            this.Reciever = Reciever;
        }
    }
}
