namespace BibliotecaApp.Application.Features.Books.DTOs.External
{
    using System.Text.Json.Serialization;

    public record OpenLibrarySearchResponse(
        [property: JsonPropertyName("docs")]
    List<OpenLibraryBookDto> Docs
    );
}
