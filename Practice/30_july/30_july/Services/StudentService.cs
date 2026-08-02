using _29_july.Models;

namespace _29_july.Services
{
    public class StudentService : IStudentService
    {
        private static List<Student> students = new List<Student>()
        {
            new Student
            {
                Id = 1,
                FirstName = "Divyansh",
                LastName = "Mate",
                Phone = "9876543210",
                BatchId = 101
            },
            new Student
            {
                Id = 2,
                FirstName = "Aditya",
                LastName = "Mishra",
                Phone = "7886543211",
                BatchId = 102
            },
            new Student
            {
                Id = 3,
                FirstName = "Ayush",
                LastName = "Gokhale",
                Phone = "8576543212",
                BatchId = 103
            },
            new Student
            {
                Id = 4,
                FirstName = "Mayur",
                LastName = "Palve",
                Phone = "9576543213",
                BatchId = 104
            }
        };

        public List<Student> getStudents()
        {
            return students;
        }

        public Student? getStudent(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        public Student? getStudentName(string firstName)
        {
            return students.FirstOrDefault(
                s => s.FirstName == firstName
            );
        }

        public Student addStudent(Student student)
        {
            students.Add(student);

            return student;
        }
    }
}