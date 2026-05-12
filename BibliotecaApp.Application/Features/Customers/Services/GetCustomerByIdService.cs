using BibliotecaApp.Application.Features.Customers.DTOs.Responses;
using BibliotecaApp.Application.Features.Customers.Interfaces;
using BibliotecaApp.Domain.Interfaces;

namespace BibliotecaApp.Application.Features.Customers.Services
{
    public class GetCustomerByIdService : IGetCustomerByIdService
    {

        private readonly ICustomerRepository _repository;


        public GetCustomerByIdService(ICustomerRepository repository)
        {
            _repository = repository;
        }


        public async Task<CustomerResponse> ExecuteAsync(long id)
        {
            var customer = await _repository.GetByIdAsync(id);

            if (customer is null)
            {
                throw AppException.NotFound(
                   "Customer not found.");
            }

            return new CustomerResponse(
              customer.Id,
              $"{customer.FirstName} {customer.LastName}",
              customer.Email,
              customer.Phone
          );
        }
    }
}
