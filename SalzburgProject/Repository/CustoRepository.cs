using Microsoft.EntityFrameworkCore;
using SalzburgProject.Data;
using SalzburgProject.Interface;
using SalzburgProject.Models;

namespace SalzburgProject.Repository
{
    public class CustoRepository : ICustoRepository
    {
        private readonly ApplicationDbContext _context;

        public CustoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Custo custo)
        {
            await _context.AddAsync(custo);
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Delete(Custo custo)
        {
            _context.Remove(custo);
        }

        public Task<IEnumerable<Custo>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Custo> GetByIdAsync(int id)
        {
            return await _context.Custos.FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }

        public void Update(Custo custo)
        {
            _context.Update(custo);
        }
    }
}
