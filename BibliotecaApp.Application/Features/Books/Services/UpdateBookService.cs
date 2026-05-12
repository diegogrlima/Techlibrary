using BibliotecaApp.Application.Features.Books.DTOs.Requests;
using BibliotecaApp.Application.Features.Books.Interfaces;
using BibliotecaApp.Domain.Entities;
using BibliotecaApp.Domain.Interfaces;

namespace BibliotecaApp.Application.Features.Books.Services
{
    public class UpdateBookService : IUpdateBookService
    {
        private readonly IBookRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;


        public UpdateBookService(IBookRepository repository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task ExecuteAsync(long id, UpdateBookRequest request)
        {
            var book = await _repository.GetByIdAsync(id);

            if (book is null)
            {
                throw AppException.NotFound("Book not found");

            }

            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);

            if (category is null)
            {
                throw AppException.NotFound("Category not found");
            }

            book.Name = request.Name;
            book.Biography = request.Biography;
            book.Author = request.Author;
            book.PublicationDate = request.PublicationDate;
            book.PageCount = request.PageCount;
            book.CategoryId = request.CategoryId;

            _repository.Update(book);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
