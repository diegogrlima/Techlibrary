
using BibliotecaApp.Application.Features.Books.Interfaces;
using BibliotecaApp.Domain.Entities;
using BibliotecaApp.Domain.Interfaces;

namespace BibliotecaApp.Application.Features.Books.Services
{
    public class DeleteBookService : IDeleteBookService
    {
        
        private readonly IBookRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBookService(IBookRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(long id)
        {
           
            var book = await _repository.GetByIdAsync(id);

            if(book is null)
            {
                throw AppException.NotFound("Book not found");
            }

             _repository.Delete(book);
            await _unitOfWork.SaveChangesAsync();

        }
    }
}
