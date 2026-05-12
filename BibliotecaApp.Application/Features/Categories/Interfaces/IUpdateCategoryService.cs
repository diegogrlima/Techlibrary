

using BibliotecaApp.Application.Features.Categories.DTOs.Requests;

namespace BibliotecaApp.Application.Features.Categories.Interfaces
{
    public interface IUpdateCategoryService
    {
        Task ExecuteAsync(long id, UpdateCategoryRequest request);
    }
}
