using Microsoft.EntityFrameworkCore;
using VictorFrye.Coldfire.Data;
using VictorFrye.Coldfire.Data.Houses;

namespace VictorFrye.Coldfire.Api.Houses
{
    public class HouseService : Service<House>
    {
        public HouseService(ColdfireDbContext dbContext) : base(dbContext) { }

        public override async Task<IList<House>> Get()
        {
            var entities = await _db.Houses.ToListAsync();

            return entities.Select(e => new House(e)).ToList();
        }

        public override async Task<House?> Find(int id)
        {
            var entity = await _db.Houses.FindAsync(id);

            return entity is not null ? new House(entity) : null;
        }
    }
}
