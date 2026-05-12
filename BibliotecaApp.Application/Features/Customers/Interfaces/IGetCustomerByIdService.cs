

using BibliotecaApp.Application.Features.Customers.DTOs.Responses;

namespace BibliotecaApp.Application.Features.Customers.Interfaces
{
    public interface IGetCustomerByIdService
    {
        Task<CustomerResponse> ExecuteAsync(long id);
    }
}
