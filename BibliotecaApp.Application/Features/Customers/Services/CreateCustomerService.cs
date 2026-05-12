using BibliotecaApp.Application.Features.Customers.DTOs.Requests;
using BibliotecaApp.Application.Features.Customers.DTOs.Responses;
using BibliotecaApp.Application.Features.Customers.Interfaces;
using BibliotecaApp.Domain.Entities;
using BibliotecaApp.Domain.Interfaces;

namespace BibliotecaApp.Application.Features.Customers.Services
{
    public class CreateCustomerService : ICreateCustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IUnitOfWork _unitOfWork;


        public CreateCustomerService(ICustomerRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }


        public async Task<CustomerResponse> ExecuteAsync(CreateCustomerRequest request)
        {
            var emailAlreadyExists =
            await _repository.GetByEmailAsync(request.Email);

            if (emailAlreadyExists is not null)
            {
                throw AppException.Conflict(
                    "Customer email already exists.");
            }

            var cpfAlreadyExists =
                await _repository.GetByCpfAsync(request.CPF);

            if (cpfAlreadyExists is not null)
            {
                throw AppException.Conflict(
                    "Customer CPF already exists.");
            }

            var customer = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                Email = request.Email,
                CPF = request.CPF
            };

            await _repository.AddAsync(customer);

            await _unitOfWork.SaveChangesAsync();

            return new CustomerResponse(
                customer.Id,
                $"{customer.FirstName} {customer.LastName}",
                customer.Email,
                customer.Phone
            );


        }
    }
}
