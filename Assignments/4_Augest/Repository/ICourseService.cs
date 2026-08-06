using _4_Augest.Models;

namespace _4_Augest.Repository
{
    public interface ICourseService
    {
        List<Course> GetAll();

        Course? GetCourse(int id);

        void AddCourse(Course course);

        void UpdateCourse(Course course);

        void DeleteCourse(int id);
    }
}