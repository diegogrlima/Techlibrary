using BibliotecaApp.Domain.Entities;
using BibliotecaApp.Domain.Interfaces;
using BibliotecaApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaApp.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {

        private readonly ApplicationDbContext _context;

        public LoanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Loan>> GetAllAsync()
        {

            return await _context.Loans
                .Include(loan => loan.Customer)
                .Include(loan => loan.Book)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Loan?> GetByIdAsync(long id)
        {
            return await _context.Loans
                .Include (loan => loan.Customer)
                .Include(loan =>loan.Book)
                .FirstOrDefaultAsync(loan => loan.Id == id);
        }

        public async Task AddAsync(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
        }

        public async Task UpdateAsync(Loan loan)
        {
             _context.Loans.Update(loan);
        }
    }
}
