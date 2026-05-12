

namespace BibliotecaApp.Application.Features.Categories.Interfaces
{
    internal interface IDeleteCategoryService
    {
        Task ExecuteAsync(long id);
    }
}
