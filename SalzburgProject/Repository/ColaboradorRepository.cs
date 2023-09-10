using Microsoft.EntityFrameworkCore;
using SalzburgProject.Data;
using SalzburgProject.Interface;
using SalzburgProject.Models;

namespace SalzburgProject.Repository
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly ApplicationDbContext _context;
        public ColaboradorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Colaborador colaborador)
        {
            _context.Add(colaborador);
            return Save();
        }

        public bool Delete(Colaborador colaborador)
        {
            _context.Remove(colaborador);
            return Save();
        }

        public async Task<IEnumerable<Colaborador>> GetAll()
        {
            return await _context.Colaboradores.ToListAsync();
        }

        public async Task<Colaborador> GetByIdAsync(int id)
        {
            return await _context.Colaboradores.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Colaborador colaborador)
        {
            _context.Update(colaborador);
            return Save();
        }

        public bool CPFExist(string cpf)
        {
            return _context.Colaboradores.Any(p => p.CPF == cpf);
        }
    }
}
