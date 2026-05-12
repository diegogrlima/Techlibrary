using Azure.Core;
using BibliotecaApp.Application.Features.Categories.DTOs.Requests;
using BibliotecaApp.Application.Features.Categories.Interfaces;
using BibliotecaApp.Application.Features.Customers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApp.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IGetAllCategoriesService _getAllCategoriesService;
        private readonly IGetCategoryByIdService _getCategoryByIdService;
        private readonly ICreateCategoryService _createCategoryService;
        private readonly IUpdateCategoryService _updateCategoryService;
        private readonly IDeleteCustomerService _deleteCustomerService;


        public CategoryController(
            IGetAllCategoriesService getAllCategoriesService,
            IGetCategoryByIdService getCategoryByIdService,
            ICreateCategoryService createCategoryService,
            IUpdateCategoryService updateCategoryService,
            IDeleteCustomerService deleteCustomerService
            )
        {
            _getAllCategoriesService = getAllCategoriesService;
            _getCategoryByIdService = getCategoryByIdService;
            _createCategoryService = createCategoryService;
            _updateCategoryService = updateCategoryService;
            _deleteCustomerService = deleteCustomerService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _getAllCategoriesService.ExecuteAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var response = await _getCategoryByIdService.ExecuteAsync(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCategoryRequest request)
        {
            var response = await _createCategoryService.ExecuteAsync(request);
            return Created(string.Empty, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, UpdateCategoryRequest request)
        {
            await _updateCategoryService.ExecuteAsync(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _deleteCustomerService.ExecuteAsync(id);
            return NoContent();
        }
    }

}
