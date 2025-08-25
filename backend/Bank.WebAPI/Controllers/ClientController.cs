using Bank.Application.DTO.Client;
using Bank.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bank.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController(IClientService clientService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string name = "")
        {
            var result = await clientService.GetAll(name);
            return Ok(result);
        }

        [HttpGet]
        [Route("{clientId}")]
        public async Task<IActionResult> Get([FromRoute] int clientId)
        {
            var result = await clientService.Get(clientId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddClientRequest client)
        {
            var result = await clientService.Add(client);
            return Ok(result);
        }

        [HttpPut("{clientId}")]
        public async Task<IActionResult> Put([FromRoute] int clientId, [FromBody] EditClientRequest client)
        {
            var result = await clientService.Update(clientId, client);

            return Ok(result);
        }

        [HttpDelete("{clientId}")]
        public async Task<IActionResult> Delete([FromRoute] int clientId)
        {
            var result = await clientService.Delete(clientId);

            return Ok(result);
        }



        [HttpGet("{clientId}/accounts")]
        public async Task<IActionResult> GetAccounts([FromRoute] int clientId)
        {
            var result = await clientService.GetAccounts(clientId);

            return Ok(result);
        }
    }
}
