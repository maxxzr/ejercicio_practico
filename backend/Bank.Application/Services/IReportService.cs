using Bank.Application.DTO.Account;
using Bank.Application.DTO.Report;
using Bank.Application.Models;
namespace Bank.Application.Services
{
    public interface IReportService
    {
        Task<List<ReportTransactionResponse>> GetReportTransaction(ReportTransactionRequest request);
    }
}
