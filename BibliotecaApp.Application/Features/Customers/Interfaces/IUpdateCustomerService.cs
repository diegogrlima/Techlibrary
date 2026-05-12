using BibliotecaApp.Application.Features.Customers.DTOs.Requests;

namespace BibliotecaApp.Application.Features.Customers.Interfaces
{
    public interface IUpdateCustomerService
    {
        Task ExecuteAsync(long id, UpdateCustomerRequest request);
    }
}
