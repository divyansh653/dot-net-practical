using _8_Augest.Models;

namespace _8_Augest.Repository
{
    public interface ITeacherService
    {
        List<Teacher> GetAll();

        Teacher GetById(int id);

        void Add(Teacher teacher);

        void Update(Teacher teacher);

        void Delete(Teacher teacher);
    }
}