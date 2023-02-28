using Microsoft.EntityFrameworkCore;
using VictorFrye.Coldfire.Data;
using VictorFrye.Coldfire.Data.Books;
using VictorFrye.Coldfire.Data.Characters;
using VictorFrye.Coldfire.Data.Houses;

namespace VictorFrye.Coldfire.Api
{
    public static class EndpointRouter
    {
        public static WebApplication MapBookRoutes(this WebApplication app)
        {
            app.MapGet("/api/books", async (ColdfireDbContext db) => await db.Books.ToListAsync())
            .WithName("GetBooks")
            .WithOpenApi();

            app.MapGet("/api/books/{bookId}", async (int bookId, ColdfireDbContext db) =>
                await db.Books.FindAsync(bookId) is BookEntity book ? Results.Ok(book) : Results.NotFound())
            .WithName("GetBookById")
            .WithOpenApi();

            return app;
        }
        public static WebApplication MapCharacterRoutes(this WebApplication app)
        {
            app.MapGet("/api/characters", async (ColdfireDbContext db) => await db.Characters.ToListAsync())
            .WithName("GetCharacters")
            .WithOpenApi();

            app.MapGet("/api/characters/{characterId}", async (int characterId, ColdfireDbContext db) =>
                await db.Characters.FindAsync(characterId) is CharacterEntity character ? Results.Ok(character) : Results.NotFound())
            .WithName("GetCharacterById")
            .WithOpenApi();

            return app;
        }

        public static WebApplication MapHouseRoutes(this WebApplication app)
        {
            app.MapGet("/api/houses", async (ColdfireDbContext db) => await db.Houses.ToListAsync())
            .WithName("GetHouses")
            .WithOpenApi();

            app.MapGet("/api/houses/{houseId}", async (int houseId, ColdfireDbContext db) =>
                await db.Houses.FindAsync(houseId) is HouseEntity house ? Results.Ok(house) : Results.NotFound())
            .WithName("GetHouseById")
            .WithOpenApi();

            return app;
        }
    }
}
