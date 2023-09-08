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
        public bool Add(Folga folga)
        {
            _context.Add(folga);
            return Save();
        }

        public bool Delete(Folga folga)
        {
            _context.Remove(folga);
            return Save();
        }

        public async Task<IEnumerable<Folga>> GetAll()
        {
            return await _context.Folgas.ToListAsync();
        }

        public async Task<Folga> GetByIdAsync(int id)
        {
            return await _context.Folgas.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Folga Folga)
        {
            _context.Update(Folga);
            return Save();
        }
    }
}
