using _29_july.Models;

namespace _29_july.Services
{
    public interface IStudentService
    {
        List<Student> getStudents();

        Student? getStudent(int id);

        Student? getStudentName(string firstName);

        Student addStudent(Student student);
    }
}