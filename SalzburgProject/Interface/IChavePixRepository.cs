using SalzburgProject.Models;
using SalzburgProject.Repository.Astraction;

namespace SalzburgProject.Interface
{
    public interface IChavePixRepository : IUnitOfWork
    {
        Task<IEnumerable<ChavePix>> GetAll();
        Task<ChavePix> GetByIdAsync(int id);
        Task Add(ChavePix chave);
        Task<IEnumerable<ChavePix>> GetAllByColaborador(int id);
        void Update(ChavePix chave);
        void Delete(ChavePix chave);
        //bool Save();
    }
}
