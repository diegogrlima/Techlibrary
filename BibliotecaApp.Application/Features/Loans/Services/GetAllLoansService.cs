using BibliotecaApp.Application.Features.Loans.DTOs.Responses;
using BibliotecaApp.Application.Features.Loans.Interfaces;
using BibliotecaApp.Domain.Interfaces;

namespace BibliotecaApp.Application.Features.Loans.Services
{
    public class GetAllLoansService : IGetAllLoansService
    {
        
        private readonly ILoanRepository _repository;

        public GetAllLoansService(ILoanRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LoanResponse>> ExecuteAsync()
        {
           var loans = await _repository.GetAllAsync();

            return loans.Select(loan => new LoanResponse(
                loan.Id,
                $"{loan.Customer!.FirstName} {loan.Customer!.LastName}",
                loan.Book!.Name,
                loan.LoanDate,
                loan.ReturnDate,
                loan.DeliveredAt,
                loan.ReturnedOnTime
                ));
        }
    }
}
