using BibliotecaApp.Application.Features.Books.DTOs.Requests;
using BibliotecaApp.Application.Features.Books.DTOs.Responses;
using BibliotecaApp.Application.Features.Books.Interfaces;
using BibliotecaApp.Domain.Entities;
using BibliotecaApp.Domain.Interfaces;

namespace BibliotecaApp.Application.Features.Books.Services
{
    public class CreateBookService : ICreateBookService
    {
        private readonly IBookRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookService(IBookRepository repository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BookResponse> ExecuteAsync(CreateBookRequest request)
        {
            var bookWithSameName = await _repository.GetByNameAsync(request.Name);

            if (bookWithSameName != null)
            {
                throw AppException.Conflict("Already existing a Book with this name");
            }

            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);

            if (category is null)
            {
                throw AppException.NotFound("Category not found");
            }


            var book = new Book
            {
                Name = request.Name,
                Biography = request.Biography,
                Author = request.Author,
                PublicationDate = request.PublicationDate,
                PageCount = request.PageCount,
                Category = category,

            };

            await _repository.AddAsync(book);
            await _unitOfWork.SaveChangesAsync();


            return new BookResponse(

                book.Id,
                book.Name,
                book.Biography,
                book.Author,
                book.PublicationDate,
                book.PageCount,
                category.Name
                );

        }
    }
}
