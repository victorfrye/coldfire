using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VictorFrye.Coldfire.Data.Books;
using VictorFrye.Coldfire.Data.Characters;
using VictorFrye.Coldfire.Data.Houses;
using System.Linq;

namespace VictorFrye.Coldfire.Seeder
{
    internal static class Seeder
    {
        public static void Seed(this ModelBuilder model)
        {
            var projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

            var books = GetDtoData<BookDto>(Path.Combine(projectFolder, @"src\Seeder\Files\books.json"));
            var characters = GetDtoData<CharacterDto>(Path.Combine(projectFolder, @"src\Seeder\Files\characters.json"));
            var houses = GetDtoData<HouseDto>(Path.Combine(projectFolder, @"src\Seeder\Files\houses.json"));

            model.InsertData(books, characters, houses);
        }

        private static void InsertData(this ModelBuilder model, List<BookDto> books, List<CharacterDto> characters, List<HouseDto> houses)
        {
            var bookEntities = books.Select(b => new BookEntity(
                id: b.Id,
                name: b.Name,
                isbn: b.Isbn,
                authors: b.Authors.ToHashSet(),
                numberOfPages: b.NumberOfPages,
                publisher: b.Publisher,
                country: b.Country,
                mediaType: b.MediaType,
                released: b.ReleaseDate,
                characters: new HashSet<CharacterEntity>(),
                povCharacters: new HashSet<CharacterEntity>()));

            var characterEntities = characters.Select(c => new CharacterEntity(
                id: c.Id,
                name: c.Name,
                gender: c.IsFemale ? "Female" : "Male",
                culture: c.Culture,
                born: c.Born,
                died: c.Died,
                titles: c.Titles.ToHashSet(),
                aliases: c.Aliases.ToHashSet(),
                father: null,
                mother: null,
                spouse: null,
                allegiances: new HashSet<HouseEntity>(),
                books: new HashSet<BookEntity>(),
                povBooks: new HashSet<BookEntity>(),
                tvSeries: c.TvSeries.ToHashSet(),
                playedBy: c.PlayedBy.ToHashSet()));

            var houseEntities = houses.Select(h => new HouseEntity(
                id: h.Id,
                name: h.Name,
                region: h.Region,
                coatOfArms: h.CoatOfArms,
                words: h.Words,
                titles: h.Titles.ToHashSet(),
                seats: h.Seats.ToHashSet(),
                currentLord: null,
                heir: null,
                overlord: null,
                founded: h.Founded,
                founder: null,
                diedOut: h.DiedOut,
                ancestralWeapons: h.AncestralWeapons.ToHashSet(),
                cadetBranches: new HashSet<HouseEntity>(),
                swornMembers: new HashSet<CharacterEntity>()));

            model.Entity<BookEntity>().HasData(bookEntities);
            model.Entity<CharacterEntity>().HasData(characterEntities);
            model.Entity<HouseEntity>().HasData(houseEntities);

            foreach (var character in characterEntities)
            {
                var data = characters.Find(c => c.Id == character.Id);

                character.Father = characterEntities.FirstOrDefault(c => c.Id == data.Father);
                character.Mother = characterEntities.FirstOrDefault(c => c.Id == data.Mother);
                character.Spouse = characterEntities.FirstOrDefault(c => c.Id == data.Spouse);
                character.Allegiances = houseEntities.Where(h => data.Allegiances.Contains(h.Id)).ToHashSet();
                character.Books = bookEntities.Where(b => data.Books.Contains(b.Id)).ToHashSet();
                character.PovBooks = bookEntities.Where(b => data.PovBooks.Contains(b.Id)).ToHashSet();

            }

            foreach (var house in houseEntities)
            {
                var data = houses.Find(h => h.Id == house.Id);

                house.CurrentLord = characterEntities.FirstOrDefault(c => c.Id == data.CurrentLord);
                house.Heir = characterEntities.FirstOrDefault(c => c.Id == data.Heir);
                house.Overlord = houseEntities.FirstOrDefault(h => h.Id == data.Overlord);
                house.Founder = characterEntities.FirstOrDefault(c => c.Id == data.Founder);
                house.CadetBranches = houseEntities.Where(h => data.CadetBranches.Contains(h.Id)).ToHashSet();
            }

            model.Entity<BookEntity>().HasData(bookEntities);
            model.Entity<CharacterEntity>().HasData(characterEntities);
            model.Entity<HouseEntity>().HasData(houseEntities);
        }

        private static List<T> GetDtoData<T>(string path)
        {
            if (!File.Exists(path))
            {
                throw new ArgumentException($"Could not find {Path.GetFullPath(path)}");
            }

            var data = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path));

            return data;
        }
    }
}
