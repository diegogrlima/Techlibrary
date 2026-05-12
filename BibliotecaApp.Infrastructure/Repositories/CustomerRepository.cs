using BibliotecaApp.Domain.Entities;
using BibliotecaApp.Domain.Interfaces;
using BibliotecaApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;


namespace BibliotecaApp.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {


        private readonly ApplicationDbContext _context;


        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Customer>> GetAllAsync()
        {

            return await _context.Customers.
                AsNoTracking()
               .ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(long id)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer?> GetByCpfAsync(string cpf)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(c => c.CPF == cpf);
        }

        public async Task<Customer?> GetByEmailAsync(string email)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(c => c.Email == email);
        }


        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
        }


        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
        }


        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }
}
