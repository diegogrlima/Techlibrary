using BibliotecaApp.Application.Features.Books.DTOs.External;
using BibliotecaApp.Application.Features.Books.Interfaces;
using System.Net.Http.Json;

namespace BibliotecaApp.Application.Features.Books.Services
{
    public class ExternalBookService : IExternalBookService
    {

        private readonly HttpClient _httpClient;

        public ExternalBookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }



        public async Task<IEnumerable<ExternalBookResponse>> SearchByTitleAsync(string title)
        {
            var response = await _httpClient.GetFromJsonAsync<OpenLibrarySearchResponse>($"search.json?title={Uri.EscapeDataString(title)}");

            if (response?.Docs is null)
            {
                return [];
            }

            return response.Docs.Take(10).Select(book =>
            {
                var coverUrl = book.CoverId.HasValue
                    ? $"https://covers.openlibrary.org/b/id/{book.CoverId.Value}-L.jpg"
                    : null;

                return new ExternalBookResponse(
                    book.Title ?? "Título não informado",
                    book.AuthorNames?.FirstOrDefault(),
                    book.FirstPublishYear,
                    book.Isbns?.FirstOrDefault(),
                    book.PageCount,
                    coverUrl,
                    book.Key
                );
            });
        }

        
    }
}
