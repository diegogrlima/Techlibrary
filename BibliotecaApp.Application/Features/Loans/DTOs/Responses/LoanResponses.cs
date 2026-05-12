namespace BibliotecaApp.Application.Features.Loans.DTOs.Responses
{
    public record LoanResponse(
     long Id,
     string CustomerName,
     string BookName,
     DateTime LoanDate,
     DateTime ReturnDate,
     DateTime? DeliveredAt,
     bool ReturnedOnTime
        );
}
