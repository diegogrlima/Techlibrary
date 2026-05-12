using BibliotecaApp.Application.Features.Loans.DTOs.Requests;
using BibliotecaApp.Application.Features.Loans.DTOs.Responses;
using BibliotecaApp.Application.Features.Loans.Interfaces;
using BibliotecaApp.Domain.Entities;
using BibliotecaApp.Domain.Interfaces;

namespace BibliotecaApp.Application.Features.Loans.Services
{
    public class CreateLoanService : ICreateLoanService
    {
        private readonly ILoanRepository _repository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public const int ReturnDays = 7;


        public CreateLoanService(ILoanRepository repository,
            ICustomerRepository customerRepository,
            IBookRepository bookRepository,
            IUnitOfWork unitOfWork
            )
        {
            _repository = repository;
            _customerRepository = customerRepository;
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<LoanResponse> ExecuteAsync(CreateLoanRequest request)
        {

            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);

            if (customer is null)
            {
                throw AppException.NotFound("Customer not found");
            }

            var book = await _bookRepository.GetByIdAsync(request.BookId);

            if (book is null)
            {
                throw AppException.NotFound("Book not found");
            }

            var loan = new Loan()
            {
                LoanDate = DateTime.Now,
                ReturnDate = DateTime.UtcNow.AddDays(ReturnDays),
                DeliveredAt = null,
                ReturnedOnTime = false,
                CustomerId = request.CustomerId,
                BookId = request.BookId,
            };

            await _repository.AddAsync(loan);
            await _unitOfWork.SaveChangesAsync();

            return new LoanResponse(
                loan.Id,
                $"{customer.FirstName} {customer.LastName}",
                book.Name,
                loan.LoanDate,
                loan.ReturnDate,
                loan.DeliveredAt,
                loan.ReturnedOnTime
                );

        }
    }
}
