using _4_Augest.Models;

namespace _4_Augest.Repository
{
    public interface IStudentService
    {
        List<Student> GetAll();

        Student? GetStudent(int id);

        void AddStudent(Student student);

        void UpdateStudent(Student student);

        void DeleteStudent(int id);
    }
}