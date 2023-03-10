using Microsoft.EntityFrameworkCore;
using VictorFrye.Coldfire.Api;
using VictorFrye.Coldfire.Api.Books;
using VictorFrye.Coldfire.Api.Characters;
using VictorFrye.Coldfire.Api.Houses;
using VictorFrye.Coldfire.Data.Books;
using VictorFrye.Coldfire.Data.Characters;
using VictorFrye.Coldfire.Data.Houses;
using VictorFrye.Coldfire.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ColdfireDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ColdfireDatabase")));
builder.Services.AddSingleton<IService<Book>, BookService>();
builder.Services.AddSingleton<IService<Character>, CharacterService>();
builder.Services.AddSingleton<IService<House>, HouseService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapBookRoutes();
app.MapCharacterRoutes();
app.MapHouseRoutes();

app.Run();