using SalzburgProject.Data;
using SalzburgProject.Interface;
using SalzburgProject.Models;

namespace SalzburgProject.Repository
{
    public class ChavePixRepository : IChavePixRepository
    {
        private readonly ApplicationDbContext _chavePixRepository;
        public ChavePixRepository(ApplicationDbContext context)
        {
            _chavePixRepository = context;
        }

        public bool Add(ChavePix chave)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ChavePix chave)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ChavePix>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ChavePix> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(ChavePix chave)
        {
            throw new NotImplementedException();
        }
    }
}
