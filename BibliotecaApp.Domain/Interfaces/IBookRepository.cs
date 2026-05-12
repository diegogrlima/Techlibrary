



using BibliotecaApp.Domain.Entities;

namespace BibliotecaApp.Domain.Interfaces
{
    public interface IBookRepository
    {

        Task<IEnumerable<Book>> GetAllAsync();

        Task<Book?> GetByIdAsync(long id);

        Task<Book?> GetByNameAsync(string name);

        Task AddAsync(Book book);


        void Update(Book book);

        void Delete(Book book);
    }
}
