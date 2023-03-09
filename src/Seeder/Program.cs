using Microsoft.EntityFrameworkCore;
using VictorFrye.Coldfire.Seeder;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SeedDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ColdfireDatabase")));

var app = builder.Build();

app.Run();
