using BibliotecaApp.Application.Features.Books.DTOs.Responses;
using BibliotecaApp.Application.Features.Books.Interfaces;
using BibliotecaApp.Domain.Interfaces;

namespace BibliotecaApp.Application.Features.Books.Services
{
    public class GetAllBooksService : IGetAllBooksService
    {

        private readonly IBookRepository _repository;


        public GetAllBooksService(IBookRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<BookResponse>> ExecuteAsync()
        {
            var books = await _repository.GetAllAsync();

            return books.Select(book => new BookResponse(
                book.Id,
                book.Name,
                book.Biography,
                book.Author,
                book.PublicationDate,
                book.PageCount,
                book.Category!.Name 
                ));
        }
    }
}
