using BibliotecaApp.Application.Features.Loans.DTOs.Responses;

namespace BibliotecaApp.Application.Features.Loans.Interfaces
{
    public interface IGetAllLoansService
    {
        Task<IEnumerable<LoanResponse>> ExecuteAsync();
    }
}
