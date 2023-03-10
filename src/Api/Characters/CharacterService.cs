using Microsoft.EntityFrameworkCore;
using VictorFrye.Coldfire.Data;
using VictorFrye.Coldfire.Data.Characters;

namespace VictorFrye.Coldfire.Api.Characters
{
    public class CharacterService : Service<Character>
    {
        public CharacterService(ColdfireDbContext db) : base(db) { }

        public override async Task<IList<Character>> Get()
        {
            var entities = await _db.Characters.ToListAsync();

            return entities.Select(e => new Character(e)).ToList();
        }

        public override async Task<Character?> Find(int id)
        {
            var entity = await _db.Characters.FindAsync(id);

            return entity is not null ? new Character(entity) : null;
        }
    }
}
