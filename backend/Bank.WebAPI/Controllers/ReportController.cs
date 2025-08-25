using Bank.Application.DTO.Report;
using Bank.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bank.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController(IReportService reportService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetReportTransaction([FromQuery] ReportTransactionRequest request)
        {
            var result = await reportService.GetReportTransaction(request);
            return Ok(result);
        }
    }
}
