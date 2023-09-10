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

        public async Task Add(ChavePix chave)
        {
            await _context.AddAsync(chave);
            //return Save();
        }

        public void Delete(ChavePix chave)
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

        //public bool Save()
        //{
        //    var saved = _context.SaveChanges();
        //    return saved > 0 ? true : false;
        //}

        public void Update(ChavePix chave)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }
    }
}
