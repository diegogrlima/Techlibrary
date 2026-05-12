namespace BibliotecaApp.Application.Features.Books.DTOs.External
{
    public record ExternalBookResponse(
    string Title,
    string? Author,
    int? FirstPublishYear,
    string? Isbn,
    int? PageCount,
    string? CoverUrl,
    string? OpenLibraryKey
);

}
