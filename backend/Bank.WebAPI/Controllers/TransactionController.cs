using Bank.Application.DTO.Account;
using Bank.Application.DTO.Transaction;
using Bank.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bank.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController(ITransactionService transactionService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await transactionService.GetAll();
            return Ok(result);
        }
    }
}
