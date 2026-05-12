
namespace BibliotecaApp.Domain.Entities
{
    public class Book
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Biography { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public DateOnly PublicationDate { get; set; }

        public string? Isbn { get; set; }

        public int? PageCount { get; set; }

        public string? CoverUrl { get; set; }

        public string? OpenLibraryKey { get; set; }

        // FK
        public long CategoryId { get; set; }

        // Relacionamento
        public Category? Category { get; set; }

        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
