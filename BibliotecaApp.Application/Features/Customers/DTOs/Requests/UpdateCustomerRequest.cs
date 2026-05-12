
namespace BibliotecaApp.Application.Features.Customers.DTOs.Requests
{
    public record UpdateCustomerRequest(
        string FirstName,
        string LastName,
        string Phone,
        string Email,
        string CPF
    );

}
