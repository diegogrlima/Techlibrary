using BibliotecaApp.Application.Features.Customers.DTOs.Requests;
using BibliotecaApp.Application.Features.Customers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApp.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICreateCustomerService _createCustomerService;
        private readonly IGetAllCustomersService _getAllCustomersService;
        private readonly IGetCustomerByIdService _getCustomerByIdService;
        private readonly IUpdateCustomerService _updateCustomerService;
        private readonly IDeleteCustomerService _deleteCustomerService;


        public CustomerController(

        IGetAllCustomersService getAllCustomersService,
        IGetCustomerByIdService getCustomerByIdService,
        ICreateCustomerService createCustomerService,
        IUpdateCustomerService updateCustomerService,
        IDeleteCustomerService deleteCustomerService
        )
        {

            _getAllCustomersService = getAllCustomersService;
            _getCustomerByIdService = getCustomerByIdService;
            _createCustomerService = createCustomerService;
            _updateCustomerService = updateCustomerService;
            _deleteCustomerService = deleteCustomerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getAllCustomersService
                .ExecuteAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _getCustomerByIdService.ExecuteAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
        [FromBody] CreateCustomerRequest request)
        {
            var response =
                await _createCustomerService.ExecuteAsync(request);

            return Created(string.Empty, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateCustomerRequest request)
        {
            await _updateCustomerService.ExecuteAsync(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _deleteCustomerService.ExecuteAsync(id);
            return NoContent();
        }

    }
}
