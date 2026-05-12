namespace BibliotecaApp.Application.Features.Loans.Interfaces
{
    public interface IRenewLoanService
    {
        Task ExecuteAsync(long id);
    }
}
