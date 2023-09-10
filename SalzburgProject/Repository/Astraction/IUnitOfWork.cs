namespace SalzburgProject.Repository.Astraction
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
        Task Rollback();
    }
}
