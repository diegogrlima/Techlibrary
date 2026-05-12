

using BibliotecaApp.Application.Features.Customers.Interfaces;
using BibliotecaApp.Domain.Entities;
using BibliotecaApp.Domain.Interfaces;

namespace BibliotecaApp.Application.Features.Customers.Services
{
    internal class DeleteCustomerService : IDeleteCustomerService
    {

        private readonly ICategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerService(ICategoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(long id)
        {
            var customer =
               await _repository.GetByIdAsync(id);

            if (customer is null)
            {
                throw AppException.NotFound(
                    "Customer not found.");
            }

            _repository.Delete(customer);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
