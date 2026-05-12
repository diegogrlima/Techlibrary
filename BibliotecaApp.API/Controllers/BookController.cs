using BibliotecaApp.Application.Features.Books.DTOs.Requests;
using BibliotecaApp.Application.Features.Books.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApp.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IGetAllBooksService _getAllBooksService;
        private readonly IGetBookByIdService _getBookByIdService;
        private readonly ICreateBookService _createBookService;
        private readonly IUpdateBookService _updateBookService;
        private readonly IDeleteBookService _deleteBookService;
        private readonly IExternalBookService _externalBookService;


        public BookController(IGetAllBooksService getAllBooksService,
            IGetBookByIdService getBookByIdService,
            ICreateBookService createBookService,
            IUpdateBookService updateBookService,
            IDeleteBookService deleteBookService,
            IExternalBookService externalBookService
            )
        {
            _getAllBooksService = getAllBooksService;
            _getBookByIdService = getBookByIdService;
            _createBookService = createBookService;
            _updateBookService = updateBookService;
            _deleteBookService = deleteBookService;
            _externalBookService = externalBookService;
           
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _getAllBooksService.ExecuteAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var response = await _getBookByIdService.ExecuteAsync(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateBookRequest request)
        {
            var response = await _createBookService.ExecuteAsync(request);
            return Created(string.Empty, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, [FromBody] UpdateBookRequest request)
        {
            await _updateBookService.ExecuteAsync(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _deleteBookService.ExecuteAsync(id);
            return NoContent();
        }


        [HttpGet("external/search")]
        public async Task<IActionResult> SearchExternalBooks(
        [FromQuery] string title)
        {
            var response =
                await _externalBookService.SearchByTitleAsync(title);

            return Ok(response);
        }
    }
}
