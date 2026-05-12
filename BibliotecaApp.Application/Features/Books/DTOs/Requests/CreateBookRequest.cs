namespace BibliotecaApp.Application.Features.Books.DTOs.Requests
{
    public record CreateBookRequest(
        string Name,
        string Biography,
        string Author,
        DateOnly PublicationDate,
        int? PageCount,
        long CategoryId
        );
    
}
