namespace _16Jul.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Course { get; set; } = string.Empty;

        // New Properties
        public string Gender { get; set; } = string.Empty;

        public string Qualification { get; set; } = string.Empty;

        public double Fees { get; set; }
    }
}