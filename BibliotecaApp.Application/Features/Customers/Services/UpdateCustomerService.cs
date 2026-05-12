using BibliotecaApp.Application.Features.Customers.DTOs.Requests;
using BibliotecaApp.Application.Features.Customers.Interfaces;
using BibliotecaApp.Domain.Entities;
using BibliotecaApp.Domain.Interfaces;


namespace BibliotecaApp.Application.Features.Customers.Services
{
    public class UpdateCustomerService : IUpdateCustomerService
    {

        private readonly ICustomerRepository _repository;
        private readonly IUnitOfWork _unitOfWork;


        public UpdateCustomerService(ICustomerRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(long id, UpdateCustomerRequest request)
        {

            var customer = await _repository.GetByIdAsync(id);


            if (customer is null)
            {
                throw AppException.NotFound(
                   "Customer not found.");
            }

            var emailAlreadyExists =
                await _repository.GetByEmailAsync(request.Email);

            if (emailAlreadyExists is not null && emailAlreadyExists.Id != id)
            {
                throw AppException.Conflict(
                    "Customer email already exists.");
            }


            var cpfAlreadyExists =
                await _repository.GetByCpfAsync(request.CPF);


            if (
                cpfAlreadyExists is not null &&
                cpfAlreadyExists.Id != id)
            {
                throw AppException.Conflict(
                    "Customer CPF already exists.");
            }

            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.Phone = request.Phone;
            customer.Email = request.Email;
            customer.CPF = request.CPF;

            _repository.Update(customer);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
