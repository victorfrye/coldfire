using Microsoft.EntityFrameworkCore;
using VictorFrye.Coldfire.Seeder;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<RawDataFiles>(builder.Configuration.GetSection("RawDataSettings"));
builder.Services.AddDbContext<SeedDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ColdfireDatabase")));

var app = builder.Build();

app.Run();
