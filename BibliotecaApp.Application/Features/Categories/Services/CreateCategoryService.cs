using BibliotecaApp.Application.Features.Categories.DTOs.Requests;
using BibliotecaApp.Application.Features.Categories.DTOs.Responses;
using BibliotecaApp.Application.Features.Categories.Interfaces;
using BibliotecaApp.Domain.Entities;
using BibliotecaApp.Domain.Interfaces;

namespace BibliotecaApp.Application.Features.Categories.Services
{

    public class CreateCategoryService : ICreateCategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryService(ICategoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryResponse> ExecuteAsync(CreateCategoryRequest request)
        {
            var categoryWithSameName =
                await _repository.GetByNameAsync(request.Name);

            if (categoryWithSameName != null)
            {
                throw AppException.Conflict(
                    "Already existing a category with this name");
            }

            var category = new Category
            {
                Name = request.Name,


            };

            await _repository.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();

            return new CategoryResponse(
                category.Id,
                category.Name
            );
        }

        
    }
}
