
namespace BibliotecaApp.Application.Features.Books.Interfaces
{
    public interface IDeleteBookService
    {
        Task ExecuteAsync(long id);
    }
}
