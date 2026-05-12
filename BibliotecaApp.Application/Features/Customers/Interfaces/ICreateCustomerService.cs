using BibliotecaApp.Application.Features.Customers.DTOs.Requests;
using BibliotecaApp.Application.Features.Customers.DTOs.Responses;

namespace BibliotecaApp.Application.Features.Customers.Interfaces
{
    public interface ICreateCustomerService
    {
        Task<CustomerResponse> ExecuteAsync(
            CreateCustomerRequest request);
    }
}
