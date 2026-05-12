using BibliotecaApp.Application.Features.Loans.DTOs.Requests;
using BibliotecaApp.Application.Features.Loans.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApp.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly IGetAllLoansService _getAllLoansService;
        private readonly IGetLoanByIdService _getLoanByIdService;
        private readonly ICreateLoanService _createLoanService;
        private readonly IReturnLoanService _returnLoanService;
        private readonly IRenewLoanService _renewLoanService;

        public LoanController(ICreateLoanService createLoanService,
            IGetAllLoansService getAllLoansService,
            IGetLoanByIdService getLoanByIdService,
            IReturnLoanService returnLoanService,
            IRenewLoanService renewLoanService
            )
        {
            _createLoanService = createLoanService;
            _getAllLoansService = getAllLoansService;
            _getLoanByIdService = getLoanByIdService;
            _returnLoanService = returnLoanService;
            _renewLoanService = renewLoanService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = await _getAllLoansService.ExecuteAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var response = await _getLoanByIdService.ExecuteAsync(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateLoanRequest request)
        {
            var response = await _createLoanService.ExecuteAsync(request);
            return Created(string.Empty, response);
        }

        [HttpPut("{id}/return")]
        public async Task<ActionResult> ReturnLoan(long id)
        {
            await _returnLoanService.ExecuteAsync(id);
            return NoContent();
        }

        [HttpPut("{id}/renew")]
        public async Task<ActionResult> RenewLoan(long id)
        {
            await _renewLoanService.ExecuteAsync(id);
            return NoContent();
        }
    }
}
