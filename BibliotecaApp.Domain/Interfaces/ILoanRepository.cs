using BibliotecaApp.Domain.Entities;

namespace BibliotecaApp.Domain.Interfaces
{
    public interface ILoanRepository
    {
        Task AddAsync(Loan loan);

        Task<IEnumerable<Loan>> GetAllAsync();

        Task<Loan?> GetByIdAsync(long id);

        Task UpdateAsync(Loan loan);

       
    }
}
