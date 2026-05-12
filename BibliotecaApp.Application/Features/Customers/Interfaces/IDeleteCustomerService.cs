namespace BibliotecaApp.Application.Features.Customers.Interfaces
{
    public interface IDeleteCustomerService
    {
        Task ExecuteAsync(long id);
    }
}
