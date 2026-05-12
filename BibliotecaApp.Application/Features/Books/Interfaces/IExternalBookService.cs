using BibliotecaApp.Application.Features.Books.DTOs.External;

namespace BibliotecaApp.Application.Features.Books.Interfaces
{
    public interface IExternalBookService
    {
        Task<IEnumerable<ExternalBookResponse>> SearchByTitleAsync(string title);

    }
}
