using _8_Augest.Data;
using _8_Augest.Models;
using _8_Augest.Repository;

namespace _8_Augest.Services
{
    public class BatchService : IBatchService
    {
        private readonly AppDbContext context;

        public BatchService(AppDbContext context)
        {
            this.context = context;
        }

        public List<Batch> GetAll()
        {
            return context.Batches.ToList();
        }

        public Batch GetById(int id)
        {
            return context.Batches.Find(id);
        }

        public void Add(Batch batch)
        {
            context.Batches.Add(batch);

            context.SaveChanges();
        }

        public void Update(Batch batch)
        {
            context.Batches.Update(batch);

            context.SaveChanges();
        }

        public void Delete(Batch batch)
        {
            context.Batches.Remove(batch);

            context.SaveChanges();
        }
    }
}