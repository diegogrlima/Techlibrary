using BibliotecaApp.Application.Features.Customers.DTOs.Responses;
using BibliotecaApp.Application.Features.Customers.Interfaces;
using BibliotecaApp.Domain.Interfaces;


namespace BibliotecaApp.Application.Features.Customers.Services
{
    public class GetAllCustomersService : IGetAllCustomersService
    {

        private readonly ICustomerRepository _repository;


        public GetAllCustomersService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CustomerResponse>> ExecuteAsync()
        {

            var customers = await _repository.GetAllAsync();

            return customers.Select(customer => new CustomerResponse(
                customer.Id,
                $"{customer.FirstName} {customer.LastName}",
                customer.Email,
                customer.Phone
            ));

        }
    }
}
