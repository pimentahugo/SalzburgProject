using Microsoft.EntityFrameworkCore;
using SalzburgProject.Models;

namespace SalzburgProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Folga> Folgas { get; set; }
        public DbSet<ChavePix> ChavesPix { get; set; }

    }
}
