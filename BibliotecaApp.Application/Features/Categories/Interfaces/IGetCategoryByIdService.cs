

using BibliotecaApp.Application.Features.Categories.DTOs.Responses;

namespace BibliotecaApp.Application.Features.Categories.Interfaces
{
    public interface IGetCategoryByIdService
    {
        Task<CategoryResponse> ExecuteAsync(long id);
    }
}
