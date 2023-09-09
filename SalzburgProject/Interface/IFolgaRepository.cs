using SalzburgProject.Models;

namespace SalzburgProject.Interface
{
    public interface IFolgaRepository
    {
        Task<IEnumerable<Folga>> GetAll();
        Task<IEnumerable<Folga>> GetAllFolgasByColaborador(int id);
        Task<Folga> GetByIdAsync(int id);
        bool Add(Folga folga);
        bool Update(Folga folga);
        bool Delete(Folga folga);
        bool Save();
    }
}
