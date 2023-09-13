using SalzburgProject.Models;
using SalzburgProject.Repository.Astraction;

namespace SalzburgProject.Interface
{
    public interface ICustoRepository : IUnitOfWork
    {
        Task<IEnumerable<Custo>> GetAll();
        Task<Custo> GetByIdAsync(int id);
        Task Add(Custo custo);
        void Update(Custo custo);
        void Delete(Custo custo);
    }
}
