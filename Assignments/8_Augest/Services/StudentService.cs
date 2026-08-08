using _8_Augest.Data;
using _8_Augest.Models;
using _8_Augest.Repository;

namespace _8_Augest.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext context;

        public StudentService(AppDbContext context)
        {
            this.context = context;
        }

        public List<Student> GetAll()
        {
            return context.Students.ToList();
        }

        public Student GetById(int id)
        {
            return context.Students.Find(id);
        }

        public void Add(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        public void Update(Student student)
        {
            context.Students.Update(student);
            context.SaveChanges();
        }

        public void Delete(Student student)
        {
            context.Students.Remove(student);
            context.SaveChanges();
        }
    }
}