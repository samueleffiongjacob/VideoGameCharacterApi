using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameCharacterApi.Model;
using VideoGameCharacterApi.Services;

namespace VideoGameCharacterApi.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    // IvedioGameCharacterService is injected into the controller through constructor injection, allowing the controller to use the service to retrieve character data.
    //dependency injection is a design pattern that allows for the decoupling of components in an application, making it easier to manage dependencies and promote testability.
    public class VedioGameController(IVedioGameCharacterService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Character>>> GetCharacters()
              => Ok(await service.GetAllCharactersAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacterById(int id)
        {
            var character = await service.GetCharacterByIdAsync(id);
            return character is not null ? Ok(character) : NotFound("Chaaracter with that given ID not Found");
            //if (character == null)
            //    return NotFound();
            //return Ok(character);
        }
    }
}
