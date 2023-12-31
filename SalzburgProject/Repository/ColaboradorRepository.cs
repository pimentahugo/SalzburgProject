﻿using Microsoft.EntityFrameworkCore;
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
        public async Task Add(Colaborador colaborador)
        {
            await _context.AddAsync(colaborador);
            //return Save();
        }

        public void Delete(Colaborador colaborador)
        {
            _context.Remove(colaborador);
            //return Save();
        }

        public async Task<IEnumerable<Colaborador>> GetAll()
        {
            return await _context.Colaboradores.ToListAsync();
        }

        public async Task<Colaborador> GetByIdAsync(int id)
        {
            return await _context.Colaboradores.FirstOrDefaultAsync(i => i.Id == id);
        }


        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Colaborador colaborador)
        {
            _context.Update(colaborador);
        }

        public bool CPFExist(string cpf)
        {
            return _context.Colaboradores.Any(p => p.CPF == cpf);
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }
    }
}
