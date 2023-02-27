using ColdfireApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

var snow = new Character(
            583,
            "Jon Snow",
            "Male",
            "Northmen",
            "In 283 AC",
            null,
            new HashSet<string> { "Lord Commander of the Night's Watch" },
            new HashSet<string>
            {
                "Lord Snow",
                "Ned Stark's Bastard",
                "The Snow of Winterfell",
                "The Crow-Come-Over",
                "The 998th Lord Commander of the Night's Watch",
                "The Bastard of Winterfell",
                "The Black Bastard of the Wall",
                "Lord Crow"
            },
            null,
            null,
            null,
            new HashSet<House>(),
            new HashSet<Book>(),
            new HashSet<Book>(),
            new HashSet<string>
            {
                "Season 1",
                "Season 2",
                "Season 3",
                "Season 4",
                "Season 5",
                "Season 6"
            },
            new HashSet<string> { "Kit Harington" }
        );

app.MapGet("/api/characters", () =>
{
    var characters = new List<Character> { snow };
    return Results.Ok(characters);
})
.WithName("GetCharacters")
.WithOpenApi();

app.MapGet("/api/characters/{characterId}", (int characterId) =>
{
    return characterId == snow.Id ? Results.Ok(snow) : Results.NotFound();
})
.WithName("GetCharacterById")
.WithOpenApi();

app.Run();