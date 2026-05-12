namespace BibliotecaApp.Application.Features.Customers.DTOs.Responses;

public sealed record CustomerResponse(
    long Id,
    string FullName,
    string Email,
    string Phone
);