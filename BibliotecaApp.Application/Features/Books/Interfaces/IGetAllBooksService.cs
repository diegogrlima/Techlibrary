using BibliotecaApp.Application.Features.Books.DTOs.Responses;


namespace BibliotecaApp.Application.Features.Books.Interfaces
{
    public interface IGetAllBooksService
    {
        Task<IEnumerable<BookResponse>> ExecuteAsync();
    }
}
