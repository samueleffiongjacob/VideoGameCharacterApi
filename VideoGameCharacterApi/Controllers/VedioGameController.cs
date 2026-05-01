using Microsoft.AspNetCore.Mvc;
using VideoGameCharacterApi.Dtos;
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
        public async Task<ActionResult<List<CharacterResponse>>> GetCharacters()
              => Ok(await service.GetAllCharactersAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterResponse>> GetCharacterById(int id)
        {
            var character = await service.GetCharacterByIdAsync(id);
            return character is not null ? Ok(character) : NotFound("Chaaracter with that given ID not Found");
            //if (character == null)
            //    return NotFound();
            //return Ok(character);
        }

        [HttpPost]
        public async Task<ActionResult<CharacterResponse>> AddCharacter(CreateCharacterRequest character)
        {
            var newCharacter = await service.AddCharacterAsync(character);
            return CreatedAtAction(nameof(GetCharacterById), new { id = newCharacter.Id }, newCharacter);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCharacter(int id, UpdateCharacterRequest character)
        {
            var isUpdated = await service.UpdateCharacterAsync(id, character);
            return isUpdated ? NoContent() : NotFound("Chaaracter with that given ID not Found");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCharacter(int id)
        {
            var isDeleted = await service.DeleteCharacterAsync(id);
            return isDeleted ? NoContent() : NotFound("Chaaracter with that given ID not Found");
        }

    }
}
