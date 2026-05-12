using System.Text.Json.Serialization;

namespace BibliotecaApp.Application.Features.Books.DTOs.External
{
    public record OpenLibraryBookDto(
    [property: JsonPropertyName("title")]
    string? Title,

    [property: JsonPropertyName("key")]
    string? Key,

    [property: JsonPropertyName("author_name")]
    List<string>? AuthorNames,

    [property: JsonPropertyName("isbn")]
    List<string>? Isbns,

    [property: JsonPropertyName("first_publish_year")]
    int? FirstPublishYear,

    [property: JsonPropertyName("number_of_pages_median")]
    int? PageCount,

    [property: JsonPropertyName("cover_i")]
    int? CoverId
);
}
