
using BibliotecaApp.Application.Features.Books.DTOs.Requests;
using BibliotecaApp.Application.Features.Books.DTOs.Responses;

namespace BibliotecaApp.Application.Features.Books.Interfaces
{
    public interface ICreateBookService
    {
        Task<BookResponse> ExecuteAsync(
       CreateBookRequest request);
    }
}
