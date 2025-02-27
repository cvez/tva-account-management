using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountsController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAccounts()
        {
            var accounts = await _accountService.GetAllAccounts();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDto>> GetAccount(int id)
        {
            var account = await _accountService.GetAccountById(id);
            if (account == null) return NotFound();

            return Ok(account);
        }

        [HttpPost]
        public async Task<ActionResult<AccountDto>> PostAccount(AccountDto accountDto)
        {
            var account = await _accountService.AddAccount(accountDto);
            return CreatedAtAction("GetAccount", new { id = account.Code }, account);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, AccountDto accountDto)
        {
            if (id != accountDto.Code) return BadRequest();

            var account = await _accountService.UpdateAccount(accountDto);
            return Ok(account);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var success = await _accountService.DeleteAccount(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
