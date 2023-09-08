using SalzburgProject.Models;

namespace SalzburgProject.Interface
{
    public interface IColaboradorRepository
    {
        Task<IEnumerable<Colaborador>> GetAll();
        Task<Colaborador> GetByIdAsync(int id);
        bool Add(Colaborador colaborador);
        bool Update(Colaborador colaborador);
        bool Delete(Colaborador colaborador);
        bool Save();
    }
}
