using Microsoft.EntityFrameworkCore;

namespace ColdfireApi
{
    public static class EndpointMapper
    {
        public static WebApplication MapBookEndpoints(this WebApplication app)
        {
            app.MapGet("/api/books", async (ColdfireDbContext db) => await db.Books.ToListAsync())
            .WithName("GetBooks")
            .WithOpenApi();

            app.MapGet("/api/books/{bookId}", async (int bookId, ColdfireDbContext db) =>
                await db.Books.FindAsync(bookId)
                    is Book book
                        ? Results.Ok(book)
                        : Results.NotFound())
            .WithName("GetBookById")
            .WithOpenApi();

            return app;
        }
        public static WebApplication MapCharacterEndpoints(this WebApplication app)
        {
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

            return app;
        }

        public static WebApplication MapHouseEndpoints(this WebApplication app)
        {
            app.MapGet("/api/houses", async (ColdfireDbContext db) => await db.Houses.ToListAsync())
            .WithName("GetHouses")
            .WithOpenApi();

            app.MapGet("/api/houses/{houseId}", async (int houseId, ColdfireDbContext db) =>
                await db.Houses.FindAsync(houseId)
                    is House house
                        ? Results.Ok(house)
                        : Results.NotFound())
            .WithName("GetHouseById")
            .WithOpenApi();

            return app;
        }
    }
}
