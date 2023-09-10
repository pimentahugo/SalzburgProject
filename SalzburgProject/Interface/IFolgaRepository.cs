using SalzburgProject.Models;
using SalzburgProject.Repository.Astraction;

namespace SalzburgProject.Interface
{
    public interface IFolgaRepository : IUnitOfWork
    {
        Task<IEnumerable<Folga>> GetAll();
        Task<IEnumerable<Folga>> GetAllFolgasByColaborador(int id);
        Task<Folga> GetByIdAsync(int id);
        Task Add(Folga folga);
        void Update(Folga folga);
        void Delete(Folga folga);
        //bool Save();
    }
}
