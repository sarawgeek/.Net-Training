using System.ComponentModel.DataAnnotations;

namespace AppWithCQRS.Models
{
    public class StatusTypes
    {
        [Key]
        public int Status_Type { get; set; }
        public string Status_Value { get; set; }

        public ICollection<AWB> awbs { get; set; }
    }
}
