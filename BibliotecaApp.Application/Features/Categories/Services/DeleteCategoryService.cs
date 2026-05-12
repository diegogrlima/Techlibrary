

using BibliotecaApp.Application.Features.Categories.Interfaces;
using BibliotecaApp.Domain.Entities;
using BibliotecaApp.Domain.Interfaces;

namespace BibliotecaApp.Application.Features.Categories.Services
{
    public class DeleteCategoryService : IDeleteCategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;


        public DeleteCategoryService(ICategoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }


        public async Task ExecuteAsync(long id)
        {
            
            var category = await 
                _repository.GetByIdAsync(id);


            if (category is null) {

                throw AppException.NotFound("Category not found");
            }

             _repository.Delete(category);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
