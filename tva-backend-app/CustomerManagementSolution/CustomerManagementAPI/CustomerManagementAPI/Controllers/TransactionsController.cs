using CustomerManagement.Application.Services;
using CustomerManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        // GET: api/<TransactionsController>
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        [HttpGet("{code}")]
        public async Task<IActionResult> GetTransactionById(int code)
        {
            try
            {
                var transaction = await _transactionService.GetTransactionByIdAsync(code);
                return Ok(transaction);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            var transactions = await _transactionService.GetAllTransactionAsync();
            return Ok(transactions);
        }

        [HttpPost]
        public async Task<IActionResult> AddTransaction([FromBody] Transaction transaction)
        {
            await _transactionService.AddTransactionAsync(transaction);
            return CreatedAtAction(nameof(GetTransactionById), new { code = transaction.Code }, transaction);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateTransaction(int code, [FromBody] Transaction transaction)
        {
            if (code != transaction.Code)
            {
                return BadRequest();
            }
            try
            {
                await _transactionService.UpdateTransactionAsync(transaction);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return NoContent();
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteTransaction(int code)
        {
            try
            {
                await _transactionService.DeleteTransactionAsync(code);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return NoContent();
        }
    }
}
