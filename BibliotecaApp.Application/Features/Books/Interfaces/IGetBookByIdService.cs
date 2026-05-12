

using BibliotecaApp.Application.Features.Books.DTOs.Responses;


namespace BibliotecaApp.Application.Features.Books.Interfaces
{
    public interface IGetBookByIdService
    {
        Task<BookResponse> ExecuteAsync(long id);
    }
}
