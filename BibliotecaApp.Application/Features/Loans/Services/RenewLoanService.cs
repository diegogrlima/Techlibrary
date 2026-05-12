using BibliotecaApp.Application.Features.Loans.Interfaces;
using BibliotecaApp.Domain.Entities;
using BibliotecaApp.Domain.Interfaces;

namespace BibliotecaApp.Application.Features.Loans.Services
{
    public class RenewLoanService : IRenewLoanService
    {
        
        private readonly ILoanRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public const int ReturnDays = 7;


        public RenewLoanService(ILoanRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(long id)
        {
            var loan = await _repository.GetByIdAsync(id);

            if (loan is null)
            {
                throw AppException.NotFound("Loan not found");
            }

            if (loan.DeliveredAt is not null)
            {
                throw AppException.Conflict("Loan already returned");
            }

            if (DateTime.UtcNow > loan.ReturnDate)
            {
                throw AppException.BadRequest("Loan is overdue and cannot be renewed");
            }

            loan.ReturnDate = loan.ReturnDate.AddDays(ReturnDays);

            await _repository.UpdateAsync(loan);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
