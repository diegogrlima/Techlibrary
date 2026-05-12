using BibliotecaApp.Domain.Entities;
using BibliotecaApp.Domain.Interfaces;
using BibliotecaApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaApp.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {

        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public  async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books
                .Include(book => book.Category)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(long id)
        {
            return await _context.Books
                .Include (book => book.Category)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Book?> GetByNameAsync(string name)
        {
            return await _context.Books
                .FirstOrDefaultAsync(b => b.Name == name);
        }

        public async Task AddAsync(Book book)
        {
           await _context.Books.AddAsync(book);
        }

        public void Update(Book book)
        {
             _context.Books.Update(book);
        }

        public void Delete(Book book)
        {
            _context.Books.Remove(book);
        }
    }
}
