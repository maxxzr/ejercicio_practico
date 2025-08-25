using Bank.Application.DTO.Person;
using Bank.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bank.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController(IPersonService personService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await personService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("{personId}")]
        public async Task<IActionResult> Get([FromRoute] int personId)
        {
            var result = await personService.Get(personId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddPersonRequest person)
        {
            var result = await personService.Add(person);
            return Ok(result);
        }

        [HttpPut("{personId}")]
        public async Task<IActionResult> Put([FromRoute] int personId, [FromBody] EditPersonRequest person)
        {
            await personService.Update(personId, person);

            return Ok();
        }

        [HttpDelete("{personId}")]
        public async Task<IActionResult> Delete([FromRoute] int personId)
        {
            await personService.Delete(personId);

            return Ok();
        }
    }
}
