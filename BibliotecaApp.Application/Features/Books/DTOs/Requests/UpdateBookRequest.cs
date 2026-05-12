

namespace BibliotecaApp.Application.Features.Books.DTOs.Requests
{
    public record UpdateBookRequest(
        string Name,
        string Biography,
        string Author,
        DateOnly PublicationDate,
        int? PageCount,
        long CategoryId

    );
    
}
