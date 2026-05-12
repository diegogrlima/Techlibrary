using BibliotecaApp.Application.Features.Loans.DTOs.Responses;
using BibliotecaApp.Application.Features.Loans.Interfaces;
using BibliotecaApp.Domain.Interfaces;

namespace BibliotecaApp.Application.Features.Loans.Services
{
    public class GetLoanByIdService : IGetLoanByIdService
    {
        private readonly ILoanRepository _repository;

        public GetLoanByIdService(ILoanRepository repository)
        {
            _repository = repository;
        }


        public async Task<LoanResponse> ExecuteAsync(long id)
        {
           
            var loan = await _repository.GetByIdAsync(id);

            if(loan is null)
            {
                throw AppException.NotFound("Loan not found");
            }


            return new LoanResponse(
               loan.Id,
               $"{loan.Customer!.FirstName} {loan.Customer!.LastName}",
               loan.Book!.Name,
               loan.LoanDate,
               loan.ReturnDate,
               loan.DeliveredAt,
               loan.ReturnedOnTime
               );
        }
    }
}
