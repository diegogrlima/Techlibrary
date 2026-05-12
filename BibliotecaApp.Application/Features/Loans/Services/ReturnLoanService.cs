using BibliotecaApp.Application.Features.Loans.Interfaces;
using BibliotecaApp.Domain.Entities;
using BibliotecaApp.Domain.Interfaces;

namespace BibliotecaApp.Application.Features.Loans.Services
{
    public class ReturnLoanService : IReturnLoanService
    {

        private readonly ILoanRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ReturnLoanService(ILoanRepository repository, IUnitOfWork unitOfWork)
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

            loan.DeliveredAt = DateTime.UtcNow;
            loan.ReturnedOnTime = loan.DeliveredAt <= loan.ReturnDate;

            await _repository.UpdateAsync(loan);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
