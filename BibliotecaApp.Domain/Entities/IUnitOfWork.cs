namespace BibliotecaApp.Domain.Entities
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
    }
}
