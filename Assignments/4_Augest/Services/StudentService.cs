using _4_Augest.Data;
using _4_Augest.Models;
using _4_Augest.Repository;

namespace _4_Augest.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext context;

        public StudentService(AppDbContext context)
        {
            this.context = context;
        }

        public void AddStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var student = context.Students.Find(id);

            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
            }
        }

        public List<Student> GetAll()
        {
            return context.Students.ToList();
        }

        public Student? GetStudent(int id)
        {
            return context.Students.Find(id);
        }

        public void UpdateStudent(Student student)
        {
            context.Students.Update(student);
            context.SaveChanges();
        }
    }
}