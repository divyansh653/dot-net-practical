using _8_Augest.Models;

namespace _8_Augest.Repository
{
    public interface ICourseService
    {
        List<Course> GetAll();

        Course GetById(int id);

        void Add(Course course);

        void Update(Course course);

        void Delete(Course course);
    }
}