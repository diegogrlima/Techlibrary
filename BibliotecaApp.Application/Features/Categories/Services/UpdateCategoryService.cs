using BibliotecaApp.Application.Features.Categories.DTOs.Requests;
using BibliotecaApp.Application.Features.Categories.Interfaces;
using BibliotecaApp.Domain.Entities;
using BibliotecaApp.Domain.Interfaces;


namespace BibliotecaApp.Application.Features.Categories.Services
{
    public class UpdateCategoryService : IUpdateCategoryService
    {

        private readonly ICategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;


        public UpdateCategoryService(ICategoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(long id, UpdateCategoryRequest request)
        {

            var category = await _repository.GetByIdAsync(id);

            if (category is null)
            {
                throw AppException.NotFound("Category not found");
            }


            var exitingSameName = await _repository.GetByNameAsync(request.Name);

            if (exitingSameName != null && exitingSameName.Id != id)
            {
                throw AppException.Conflict(
                   "Already existing a category with this name");
            }


            category.Name = request.Name;

            _repository.Update(category);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
