namespace _30_july.Models
{
    public class Batch
    {
        public int Id { get; set; }

        public string BatchName { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public int CourseId { get; set; }
    }
}