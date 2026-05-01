using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.DataBase;
using VideoGameCharacterApi.Dtos;
using VideoGameCharacterApi.Model;

namespace VideoGameCharacterApi.Services
{
    public class VedioGameCharacterService(AppDbContext context) : IVedioGameCharacterService
    {

        // In-memory data store for characters before adding AppDbContext above
        //static List<Character> characters = new List<Character>
        //{
        //    new Character { Id = 1, Name = "Mario", Game = "Super Mario", Role = "Protagonist" },
        //    new Character { Id = 2, Name = "Link", Game = "The Legend of Zelda", Role = "Protagonist" },
        //    new Character { Id = 3, Name = "Master Chief", Game = "Halo", Role = "Protagonist" },
        //    new Character { Id = 4, Name = "Lara Croft", Game = "Tomb Raider", Role = "Protagonist" },
        //    new Character { Id = 5, Name = "Kratos", Game = "God of War", Role = "Princess" }
        //};

        public async Task<CharacterResponse> AddCharacterAsync(CreateCharacterRequest character)
        {
            var newCharacter = new Character
            {
                Name = character.Name,
                Game = character.Game,
                Role = character.Role
            };

            context.Characters.Add(newCharacter);
            await context.SaveChangesAsync();

            return new CharacterResponse
            {
                Id = newCharacter.Id,
                Name = newCharacter.Name,
                Game = newCharacter.Game,
                Role = newCharacter.Role
            };
        }

        public async Task<bool> DeleteCharacterAsync(int id)
        {
            var characterToDelete = await context.Characters.FindAsync(id);
            if (characterToDelete is null)
            {
                return false;
            }
            context.Characters.Remove(characterToDelete);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CharacterResponse>> GetAllCharactersAsync()
              //=> await Task.FromResult(characters); // before adding AppDbContext above
              //=> await context.Characters.ToListAsync(); // after adding AppDbContext above
              => await context.Characters.Select(c => new CharacterResponse
              {
                  Id = c.Id,
                  Name = c.Name,
                  Game = c.Game,
                  Role = c.Role
              }).ToListAsync();

        public async Task<CharacterResponse?> GetCharacterByIdAsync(int id)
        {
            /*// before adding AppDbContext above
             var character = characters.FirstOrDefault(c => c.Id == id);
             return Task.FromResult(character); 
             */
            // after adding AppDbContext above
            //var character = await context.Characters.FindAsync(id);
            //return character; 
            //dto
            var result = await context.Characters
                .Where(c => c.Id == id)
                .Select(c => new CharacterResponse
                {
                    Id = c.Id,
                    Name = c.Name,
                    Game = c.Game,
                    Role = c.Role
                })
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> UpdateCharacterAsync(int id, UpdateCharacterRequest character)
        {
            var existingCharacter = await context.Characters.FindAsync(id);
            if (existingCharacter is null)
            {
                return false;
            }
            existingCharacter.Name = character.Name;
            existingCharacter.Game = character.Game;
            existingCharacter.Role = character.Role;
            await context.SaveChangesAsync();
            return true;    
        }
    }
}
