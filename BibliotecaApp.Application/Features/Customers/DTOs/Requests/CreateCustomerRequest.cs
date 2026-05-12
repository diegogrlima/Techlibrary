namespace BibliotecaApp.Application.Features.Customers.DTOs.Requests;

public sealed record CreateCustomerRequest(
    string FirstName,
    string LastName,
    string Phone,
    string Email,
    string CPF
);