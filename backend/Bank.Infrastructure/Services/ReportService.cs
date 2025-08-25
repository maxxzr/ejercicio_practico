using AutoMapper;
using Bank.Application.DTO.Account;
using Bank.Application.DTO.Report;
using Bank.Application.DTO.Transaction;
using Bank.Application.Repositories;
using Bank.Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Bank.Infrastructure.Services
{
    public class ReportService(
            IMapper mapper,
            ITransactionRepository transactionRepository,
            IValidator<AddAccountRequest> addAccountRequestValidator, IValidator<EditAccountRequest> editAccountRequestValidator, IValidator<AddTransactionRequest> addTransactionRequest
        ) : IReportService
    {
        public async Task<List<ReportTransactionResponse>> GetReportTransaction(ReportTransactionRequest request)
        {

            var transactionsQuery = transactionRepository.Fetch()
                .Where(t => t.DateTransaction >= request.StartDate && t.DateTransaction <= request.EndDate)
                .Where(t => t.Account.Client.Person.DocumentNumber == request.DocumentNumber);

            var result = await mapper.ProjectTo<ReportTransactionResponse>(transactionsQuery).ToListAsync();

            return result;
        }
    }
}
