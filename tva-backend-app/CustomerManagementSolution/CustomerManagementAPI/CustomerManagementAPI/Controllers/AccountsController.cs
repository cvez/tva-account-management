using CustomerManagement.Application.Services;
using CustomerManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        // GET: api/<AccountsController>

        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet("{code}")]
        public async Task<IActionResult> GetAccountById(int code)
        {
            try
            {
                var account = await _accountService.GetAccountByIdAsync(code);
                return Ok(account);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var accounts = await _accountService.GetAllAccountsAsync();
            return Ok(accounts);
        }

        [HttpPost]
        public async Task<IActionResult> AddAccount([FromBody] Account account)
        {
            await _accountService.AddAccountAsync(account);
            return CreatedAtAction(nameof(GetAccountById), new { code = account.Code }, account);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateAccount(int code, [FromBody] Account account)
        {
            if (code != account.Code)
            {
                return BadRequest();
            }
            try
            {
                await _accountService.UpdateAccountAsync(account);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return NoContent();
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteAccount(int code)
        {
            try
            {
                await _accountService.DeleteAccountAsync(code);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return NoContent();
        }

    }
}
