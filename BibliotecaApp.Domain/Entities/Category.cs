namespace BibliotecaApp.Domain.Entities
{
    public class Category
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        // Relacionamento
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
