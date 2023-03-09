using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VictorFrye.Coldfire.Data;

namespace VictorFrye.Coldfire.Seeder
{
    internal class SeedDbContext : ColdfireDbContext
    {
        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);

            model.Seed();
        }

        public SeedDbContext(DbContextOptions<ColdfireDbContext> options) : base(options) { }
    }
}
