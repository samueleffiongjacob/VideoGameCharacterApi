using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Model;

namespace VideoGameCharacterApi.DataBase
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Character> Characters => Set<Character>();
    }
}
