using VideoGameCharacterApi.Model;

namespace VideoGameCharacterApi.Services
{
    public class VedioGameCharacterService : IVedioGameCharacterService
    {
        static List<Character> characters = new List<Character>
        {
            new Character { Id = 1, Name = "Mario", Game = "Super Mario", Role = "Protagonist" },
            new Character { Id = 2, Name = "Link", Game = "The Legend of Zelda", Role = "Protagonist" },
            new Character { Id = 3, Name = "Master Chief", Game = "Halo", Role = "Protagonist" },
            new Character { Id = 4, Name = "Lara Croft", Game = "Tomb Raider", Role = "Protagonist" },
            new Character { Id = 5, Name = "Kratos", Game = "God of War", Role = "Princess" }
        };

        public Task<Character> AddCharacterAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCharacterAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Character>> GetAllCharactersAsync()
             => await Task.FromResult(characters);

        public Task<Character?> GetCharacterByIdAsync(int id)
        {
            var character = characters.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(character); 
        }

        public Task<bool> UpdateCharacterAsync(int id, Character character)
        {
            throw new NotImplementedException();
        }
    }
}
