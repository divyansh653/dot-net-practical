using _8_Augest.Data;
using _8_Augest.Models;
using _8_Augest.Repository;

namespace _8_Augest.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly AppDbContext context;

        public TeacherService(AppDbContext context)
        {
            this.context = context;
        }

        public List<Teacher> GetAll()
        {
            return context.Teachers.ToList();
        }

        public Teacher GetById(int id)
        {
            return context.Teachers.Find(id);
        }

        public void Add(Teacher teacher)
        {
            context.Teachers.Add(teacher);

            context.SaveChanges();
        }

        public void Update(Teacher teacher)
        {
            context.Teachers.Update(teacher);

            context.SaveChanges();
        }

        public void Delete(Teacher teacher)
        {
            context.Teachers.Remove(teacher);

            context.SaveChanges();
        }
    }
}