namespace BibliotecaApp.Application.Exceptions
{
    public class AppException : Exception
    {
        private const int BadRequestStatusCode = 400;
        private const int NotFoundStatusCode = 404;
        private const int ConflictStatusCode = 409;

        public int StatusCode { get; }

        public AppException(string message, int statusCode = BadRequestStatusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public static AppException BadRequest(string message)
        {
            return new AppException(message, BadRequestStatusCode);
        }

        public static AppException NotFound(string message)
        {
            return new AppException(message, NotFoundStatusCode);
        }

        public static AppException Conflict(string message)
        {
            return new AppException(message, ConflictStatusCode);
        }
    }
}
