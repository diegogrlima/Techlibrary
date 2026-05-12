namespace BibliotecaApp.Application.Features.Loans.DTOs.Requests
{
    public record CreateLoanRequest(
        long CustomerId,
        long BookId
        );
    
}
