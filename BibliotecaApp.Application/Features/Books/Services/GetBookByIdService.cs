using BibliotecaApp.Application.Features.Books.DTOs.Responses;
using BibliotecaApp.Application.Features.Books.Interfaces;
using BibliotecaApp.Domain.Interfaces;

namespace BibliotecaApp.Application.Features.Books.Services
{
    internal class GetBookByIdService : IGetBookByIdService
    {

        private readonly IBookRepository _repository;


        public GetBookByIdService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<BookResponse> ExecuteAsync(long id)
        {
            var book = await _repository.GetByIdAsync(id);

            if (book is null) 
            {
                throw AppException.NotFound("Book not found");
            }

            return new BookResponse(
                book.Id,
                book.Name,
                book.Biography,
                book.Author,
                book.PublicationDate,
                book.PageCount,
                book.Category!.Name
                );
        }
    }
}
