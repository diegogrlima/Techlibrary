
using BibliotecaApp.Domain.Entities;

namespace BibliotecaApp.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();

        Task<Category?> GetByIdAsync(long id);

        Task<Category?> GetByNameAsync(string name);

        Task AddAsync(Category category);


        void Update(Category category);

        void Delete(Category category);
    }
}
