using BibliotecaApp.Application.Features.Categories.DTOs.Responses;
using BibliotecaApp.Application.Features.Categories.Interfaces;
using BibliotecaApp.Domain.Interfaces;

namespace BibliotecaApp.Application.Features.Categories.Services
{
    internal class GetCategoryByIdService : IGetCategoryByIdService
    {
        private readonly ICategoryRepository _repository;


        public GetCategoryByIdService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CategoryResponse> ExecuteAsync(long id)
        {
            var category = await _repository.GetByIdAsync(id);

            if(category is null)
            {
                throw AppException.NotFound("Category not found");
            }

            return new CategoryResponse(
                category.Id, 
                category.Name);
            
        }
    }
}
