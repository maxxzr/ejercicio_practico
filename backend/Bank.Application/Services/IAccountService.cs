using Bank.Application.DTO.Account;
using Bank.Application.DTO.Transaction;
using Bank.Application.Models;
namespace Bank.Application.Services
{
    public interface IAccountService
    {
        Task<GetAccountModel> Get(int accountId);

        Task<ResponseResult> Add(AddAccountRequest account);

        Task<ResponseResult> Update(int accountId, EditAccountRequest account);

        Task<ResponseResult> AddTransaction(int accountId, AddTransactionRequest transaction);

        Task<ResponseResult> Delete(int accountId);

        Task<List<GetAccountModel>> GetAll();

        Task<List<GetAccountTransactionResponse>> GetTransactions(int accountId);
    }
}
