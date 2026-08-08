using _8_Augest.Data;
using _8_Augest.Models;
using _8_Augest.Repository;

namespace _8_Augest.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext context;

        public CourseService(AppDbContext context)
        {
            this.context = context;
        }

        public List<Course> GetAll()
        {
            return context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return context.Courses.Find(id);
        }

        public void Add(Course course)
        {
            context.Courses.Add(course);

            context.SaveChanges();
        }

        public void Update(Course course)
        {
            context.Courses.Update(course);

            context.SaveChanges();
        }

        public void Delete(Course course)
        {
            context.Courses.Remove(course);

            context.SaveChanges();
        }
    }
}