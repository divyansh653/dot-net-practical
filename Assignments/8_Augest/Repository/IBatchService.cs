using _8_Augest.Models;

namespace _8_Augest.Repository
{
    public interface IBatchService
    {
        List<Batch> GetAll();

        Batch GetById(int id);

        void Add(Batch batch);

        void Update(Batch batch);

        void Delete(Batch batch);
    }
}