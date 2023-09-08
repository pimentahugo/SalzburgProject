using SalzburgProject.Models;

namespace SalzburgProject.Interface
{
    public interface IChavePixRepository
    {
        Task<IEnumerable<ChavePix>> GetAll();
        Task<ChavePix> GetByIdAsync(int id);
        bool Add(ChavePix folga);
        bool Update(ChavePix folga);
        bool Delete(ChavePix folga);
        bool Save();
    }
}
