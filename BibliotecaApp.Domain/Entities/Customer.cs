namespace BibliotecaApp.Domain.Entities
{
    public class Customer
    {
        public long Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
            
        public string Email { get; set; } = string.Empty;

        public string CPF { get; set; } = string.Empty;

        // Relacionamentos
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
