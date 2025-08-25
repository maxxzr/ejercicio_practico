using Bank.Application.DTO.Transaction;
namespace Bank.Application.Services
{
    public interface ITransactionService
    {
        Task<List<GetTransactionResponse>> GetAll();
    }
}
