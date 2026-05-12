namespace BibliotecaApp.API.DTOs.Errors
{
    public record ErrorResponse(
        int StatusCode,
        string Message,
        string Path
    );
}
