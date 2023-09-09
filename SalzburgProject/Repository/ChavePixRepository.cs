using Microsoft.EntityFrameworkCore;
using SalzburgProject.Data;
using SalzburgProject.Interface;
using SalzburgProject.Models;

namespace SalzburgProject.Repository
{
    public class ChavePixRepository : IChavePixRepository
    {
        private readonly ApplicationDbContext _context;
        public ChavePixRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(ChavePix chave)
        {
            _context.Add(chave);
            return Save();
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
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(ChavePix chave)
        {
            throw new NotImplementedException();
        }
    }
}
