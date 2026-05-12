using BibliotecaApp.Application.Features.Loans.DTOs.Requests;
using BibliotecaApp.Application.Features.Loans.DTOs.Responses;

namespace BibliotecaApp.Application.Features.Loans.Interfaces
{
    public interface ICreateLoanService
    {
        Task<LoanResponse> ExecuteAsync(
            CreateLoanRequest request);
    }
}
