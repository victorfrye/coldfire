using VictorFrye.Coldfire.Data.Books;
using VictorFrye.Coldfire.Data.Characters;
using VictorFrye.Coldfire.Data.Houses;

namespace VictorFrye.Coldfire.Api
{
    public static class EndpointRouter
    {
        public static WebApplication MapBookRoutes(this WebApplication app)
        {
            app.MapGet("/api/books", async (IService<Book> service) => await service.Get())
            .WithName("GetBooks")
            .WithOpenApi();

            app.MapGet("/api/books/{bookId}", async (int bookId, IService<Book> service) =>
                await service.Find(bookId) is Book book
                    ? Results.Ok(book)
                    : Results.NotFound())
            .WithName("GetBookById")
            .WithOpenApi();

            return app;
        }
        public static WebApplication MapCharacterRoutes(this WebApplication app)
        {
            app.MapGet("/api/characters", async (IService<Character> service) => Results.Ok(await service.Get()))
            .WithName("GetCharacters")
            .WithOpenApi();

            app.MapGet("/api/characters/{characterId}", async (int characterId, IService<Character> service) =>
                await service.Find(characterId) is Character character
                    ? Results.Ok(character)
                    : Results.NotFound())
            .WithName("GetCharacterById")
            .WithOpenApi();

            return app;
        }

        public static WebApplication MapHouseRoutes(this WebApplication app)
        {
            app.MapGet("/api/houses", async (IService<House> service) => await service.Get())
            .WithName("GetHouses")
            .WithOpenApi();

            app.MapGet("/api/houses/{houseId}", async (int houseId, IService<House> service) =>
                await service.Find(houseId) is House house
                    ? Results.Ok(house)
                    : Results.NotFound())
            .WithName("GetHouseById")
            .WithOpenApi();

            return app;
        }
    }
}
