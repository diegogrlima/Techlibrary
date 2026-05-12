namespace BibliotecaApp.Domain.Entities;

public class Loan
{
    public long Id { get; set; }

    public DateTime LoanDate { get; set; } // Data em que o empréstimo foi realizado

    public DateTime ReturnDate { get; set; } // Data prevista para devolução do livro

    // Data real em que o livro foi entregue
    // Pode ser nula caso ainda não tenha sido devolvido
    public DateTime? DeliveredAt { get; set; }

    // Indica se o livro foi devolvido dentro do prazo
    public bool ReturnedOnTime { get; set; }

    // FK Customer
    public long CustomerId { get; set; }

    public Customer? Customer { get; set; }

    // FK Book
    public long BookId { get; set; }

    public Book? Book { get; set; }
}