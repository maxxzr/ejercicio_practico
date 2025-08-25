using Bank.Application.DTO.Account;
using Bank.Application.DTO.Transaction;
using Bank.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bank.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController(IAccountService accountService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await accountService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("{accountId}")]
        public async Task<IActionResult> Get([FromRoute] int accountId)
        {
            var result = await accountService.Get(accountId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddAccountRequest account)
        {
            var result = await accountService.Add(account);
            return Ok(result);
        }

        [HttpPut("{accountId}")]
        public async Task<IActionResult> Put([FromRoute] int accountId, [FromBody] EditAccountRequest account)
        {
            var result = await accountService.Update(accountId, account);

            return Ok(result);
        }

        [HttpDelete("{accountId}")]
        public async Task<IActionResult> Delete([FromRoute] int accountId)
        {
            var result = await accountService.Delete(accountId);

            return Ok(result);
        }

        [HttpGet("{accountId}/transactions")]
        public async Task<IActionResult> GetTransactions([FromRoute] int accountId)
        {
            var result = await accountService.GetTransactions(accountId);

            return Ok(result);
        }

        [HttpPost("{accountId}/transaction")]
        public async Task<IActionResult> AddTransaction([FromRoute] int accountId, [FromBody] AddTransactionRequest account)
        {
            var result = await accountService.AddTransaction(accountId, account);

            return Ok(result);
        }
    }
}
