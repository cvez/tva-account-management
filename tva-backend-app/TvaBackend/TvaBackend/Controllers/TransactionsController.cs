using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public TransactionsController(ITransactionService transactionService, IMapper mapper)
        {
            _transactionService = transactionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> GetTransactions()
        {
            var transactions = await _transactionService.GetAllTransactions();
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDto>> GetTransaction(int id)
        {
            var transaction = await _transactionService.GetTransactionById(id);
            if (transaction == null) return NotFound();

            return Ok(transaction);
        }

        [HttpPost]
        public async Task<ActionResult<TransactionDto>> PostTransaction(TransactionDto transactionDto)
        {
            var transaction = await _transactionService.AddTransaction(transactionDto);
            return CreatedAtAction("GetTransaction", new { id = transaction.Code }, transaction);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaction(int id, TransactionDto transactionDto)
        {
            if (id != transactionDto.Code) return BadRequest();

            var transaction = await _transactionService.UpdateTransaction(transactionDto);
            return Ok(transaction);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var success = await _transactionService.DeleteTransaction(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
