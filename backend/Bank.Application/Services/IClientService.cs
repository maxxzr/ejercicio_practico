using Bank.Application.DTO.Client;
using Bank.Application.Models;
namespace Bank.Application.Services
{
    public interface IClientService
    {
        Task<GetClientModel> Get(int clientId);

        Task<ResponseResult> Add(AddClientRequest client);

        Task<ResponseResult> Update(int ClientId, EditClientRequest client);

        Task<ResponseResult> Delete(int clientId);

        Task<List<GetClientModel>> GetAll(string name);
        Task<List<GetAccountClientModel>> GetAccounts(int clientId);
    }
}
