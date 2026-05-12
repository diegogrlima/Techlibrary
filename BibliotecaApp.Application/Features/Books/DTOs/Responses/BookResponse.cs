namespace BibliotecaApp.Application.Features.Books.DTOs.Responses
{
    public record BookResponse(
        long Id,
        string Name,
        string Biography,
        string Author,
        DateOnly PublicationDate,
        int? PageCount,
        string Category
        );

}
