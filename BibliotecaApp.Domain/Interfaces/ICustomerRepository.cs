

using BibliotecaApp.Domain.Entities;

namespace BibliotecaApp.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();

        Task<Customer?> GetByIdAsync(long id);

        Task<Customer?> GetByCpfAsync(string cpf);

        Task<Customer?> GetByEmailAsync(string email);

        Task AddAsync(Customer customer);

        void Update(Customer customer);

        void Delete(Customer customer);
    }
}
