using BibliotecaApp.Application.Features.Customers.DTOs.Responses;

namespace BibliotecaApp.Application.Features.Customers.Interfaces
{
    public interface IGetAllCustomersService
    {
        Task<IEnumerable<CustomerResponse>> ExecuteAsync();
    }
}
