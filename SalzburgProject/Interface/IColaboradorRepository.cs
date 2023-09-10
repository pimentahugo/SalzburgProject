using SalzburgProject.Models;
using SalzburgProject.Repository.Astraction;

namespace SalzburgProject.Interface
{
    public interface IColaboradorRepository : IUnitOfWork
    {
        Task<IEnumerable<Colaborador>> GetAll();
        Task<Colaborador> GetByIdAsync(int id);
        Task Add(Colaborador colaborador);
        void Update(Colaborador colaborador);
        void Delete(Colaborador colaborador);
        //bool Save();
        bool CPFExist(string cpf);


    }
}
