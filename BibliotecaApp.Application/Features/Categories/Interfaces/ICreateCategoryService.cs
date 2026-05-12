using BibliotecaApp.Application.Features.Categories.DTOs.Requests;
using BibliotecaApp.Application.Features.Categories.DTOs.Responses;

namespace BibliotecaApp.Application.Features.Categories.Interfaces
{



    public interface ICreateCategoryService
    {
         Task<CategoryResponse> ExecuteAsync(
        CreateCategoryRequest request);
    }
}
