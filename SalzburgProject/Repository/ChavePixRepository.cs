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
            _context.Remove(chave);
        }

        public async Task<IEnumerable<ChavePix>> GetAll()
        {
            return await _context.ChavesPix.ToListAsync();
        }

        public async Task<IEnumerable<ChavePix>> GetAllByColaborador(int id)
        {
            return await _context.ChavesPix.Where(p => p.ColaboradorId == id).ToListAsync();
        }

        public async Task<ChavePix> GetByIdAsync(int id)
        {
            return await _context.ChavesPix.FirstOrDefaultAsync(p => p.Id == id);
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
