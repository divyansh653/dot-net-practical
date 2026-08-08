using System.ComponentModel.DataAnnotations;

namespace _8_Augest.Models
{
    public class Batch
    {
        public int BatchId { get; set; }

        [Required]
        public string BatchName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}