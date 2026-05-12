using BibliotecaApp.Application.Features.Categories.DTOs.Responses;
using BibliotecaApp.Application.Features.Categories.Interfaces;
using BibliotecaApp.Domain.Interfaces;

namespace BibliotecaApp.Application.Features.Categories.Services
{
    public class GetAllCategoriesService : IGetAllCategoriesService
    {

        private readonly ICategoryRepository _repository;

        public GetAllCategoriesService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CategoryResponse>> ExecuteAsync()
        {
            var categories = await _repository.GetAllAsync();

            return categories.Select(category =>
            new CategoryResponse(
                category.Id,
                category.Name
                ));
        }
    }
}
