using SalzburgProject.Models;
using SalzburgProject.Repository.Astraction;

namespace SalzburgProject.Interface
{
    public interface IChavePixRepository : IUnitOfWork
    {
        Task<IEnumerable<ChavePix>> GetAll();
        Task<ChavePix> GetByIdAsync(int id);
        Task Add(ChavePix folga);
        void Update(ChavePix folga);
        void Delete(ChavePix folga);
        //bool Save();
    }
}
