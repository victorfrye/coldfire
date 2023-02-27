using ColdfireApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ColdfireDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("ColdfireDatabase")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/characters", async (ColdfireDbContext db) => await db.Characters.ToListAsync())
.WithName("GetCharacters")
.WithOpenApi();

app.MapGet("/api/characters/{characterId}", async (int characterId, ColdfireDbContext db) =>
    await db.Characters.FindAsync(characterId)
        is Character character
            ? Results.Ok(character)
            : Results.NotFound())
.WithName("GetCharacterById")
.WithOpenApi();

app.Run();