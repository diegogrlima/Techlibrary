using BibliotecaApp.Application.Features.Books.DTOs.Requests;

namespace BibliotecaApp.Application.Features.Books.Interfaces
{
    public interface IUpdateBookService
    {
        Task ExecuteAsync(long id, UpdateBookRequest request);
    }
}

