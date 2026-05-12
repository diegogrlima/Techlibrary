

using BibliotecaApp.Domain.Entities;
using BibliotecaApp.Domain.Interfaces;
using BibliotecaApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaApp.Infrastructure.Repositories
{
    internal class CategoryRepository : ICategoryRepository
    {

        private readonly ApplicationDbContext _context;


        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context
                .Categories
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(long id)
        {
            return await _context
                 .Categories
                 .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(c => c.Name == name);
        }
        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        public async void Update(Category category)
        {
             _context.Categories.Update(category);
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        
    }
}
