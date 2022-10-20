using System.ComponentModel.DataAnnotations;

namespace AppWithEFCore.Models
{
    public class StatusTypes
    {
        [Key]
        public int Status_Type { get; set; }
        public string Status_Value { get; set; }
    }
}
