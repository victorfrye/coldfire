using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VictorFrye.Coldfire.Data;

namespace VictorFrye.Coldfire.Seeder
{
    internal class SeedDbContext : ColdfireDbContext
    {
        private readonly RawDataFiles _files;

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);

            model.Seed(_files);
        }

        public SeedDbContext(DbContextOptions<ColdfireDbContext> options, IOptionsSnapshot<RawDataFiles> files) : base(options)
        {
            _files = files.Value;
        }
    }
}
