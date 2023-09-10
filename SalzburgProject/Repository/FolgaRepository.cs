using Microsoft.EntityFrameworkCore;
using SalzburgProject.Data;
using SalzburgProject.Interface;
using SalzburgProject.Models;

namespace SalzburgProject.Repository
{
    public class FolgaRepository : IFolgaRepository
    {
        private readonly ApplicationDbContext _context;
        public FolgaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Folga folga)
        {
           await _context.AddAsync(folga);
            //return Save();
        }

        public void Delete(Folga folga)
        {
            _context.Remove(folga);
            //return Save();
        }

        public async Task<IEnumerable<Folga>> GetAll()
        {
            return await _context.Folgas.Include(folga => folga.Colaborador).ToListAsync();
        }

        public async Task<Folga> GetByIdAsync(int id)
        {
            return await _context.Folgas.FirstOrDefaultAsync(i => i.Id == id);
        }

        //public bool Save()
        //{
        //    var saved = _context.SaveChanges();
        //    return saved > 0 ? true : false;
        //}

        public void Update(Folga Folga)
        {
            _context.Update(Folga);
            //return Save();
        }
        public async Task<IEnumerable<Folga>> GetAllFolgasByColaborador(int id)
        {
            return await _context.Folgas.Include(folga => folga.Colaborador).Where(p => p.ColaboradorId == id).ToListAsync();
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
