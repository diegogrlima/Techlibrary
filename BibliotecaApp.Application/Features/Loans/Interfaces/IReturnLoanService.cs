namespace BibliotecaApp.Application.Features.Loans.Interfaces
{
    public interface IReturnLoanService
    {
        Task ExecuteAsync(long id);
    }
}
