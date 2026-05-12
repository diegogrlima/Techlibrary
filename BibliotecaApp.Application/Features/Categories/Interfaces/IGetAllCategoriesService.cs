
using BibliotecaApp.Application.Features.Categories.DTOs.Responses;

namespace BibliotecaApp.Application.Features.Categories.Interfaces
{
    public interface IGetAllCategoriesService
    {
        Task<IEnumerable<CategoryResponse>> ExecuteAsync();
    }
}
