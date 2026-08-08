using _8_Augest.Models;

namespace _8_Augest.Repository
{
    public interface IStudentService
    {
        List<Student> GetAll();

        Student GetById(int id);

        void Add(Student student);

        void Update(Student student);

        void Delete(Student student);
    }
}