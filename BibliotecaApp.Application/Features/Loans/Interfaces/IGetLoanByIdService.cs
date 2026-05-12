using BibliotecaApp.Application.Features.Loans.DTOs.Responses;

namespace BibliotecaApp.Application.Features.Loans.Interfaces
{
    public interface IGetLoanByIdService
    {
        Task<LoanResponse> ExecuteAsync(long id);
    }
}
