using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VictorFrye.Coldfire.Data.Books;
using VictorFrye.Coldfire.Data.Characters;
using VictorFrye.Coldfire.Data.Houses;

namespace VictorFrye.Coldfire.Seeder
{
    internal static class Seeder
    {
        public static void Seed(this ModelBuilder model)
        {
            var projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

            var bookData = GetDtoData<BookDto>(Path.Combine(projectFolder, @"Seeder\files\books.json"));
            var characterData = GetDtoData<CharacterDto>(Path.Combine(projectFolder, @"Seeder\files\characters.json"));
            var houseData = GetDtoData<HouseDto>(Path.Combine(projectFolder, @"Seeder\files\houses.json"));

            model.InsertData(bookData, characterData, houseData);
        }

        private static void InsertData(this ModelBuilder model, List<BookDto> bookData, List<CharacterDto> characterData, List<HouseDto> houseData)
        {
            var bookEntities = bookData.Select(b => new BookEntity(
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

            var characterEntities = characterData.Select(c => new CharacterEntity(
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

            var houseEntities = houseData.Select(h => new HouseEntity(
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

            foreach (var house in houseEntities)
            {
                var datum = houseData.Find(h => h.Id == house.Id);

                house.CurrentLord = characterEntities.FirstOrDefault(c => c.Id == datum.CurrentLord);
                house.Heir = characterEntities.FirstOrDefault(c => c.Id == datum.Heir);
                house.Overlord = houseEntities.FirstOrDefault(h => h.Id == datum.Overlord);
                house.Founder = characterEntities.FirstOrDefault(c => c.Id == datum.Founder);
                house.CadetBranches = houseEntities.Where(h => datum.CadetBranches.Contains(h.Id)).ToHashSet();
            }

            foreach (var character in characterEntities)
            {
                var datum = characterData.Find(c => c.Id == character.Id);

                character.Father = characterEntities.FirstOrDefault(c => c.Id == datum.Father);
                character.Mother = characterEntities.FirstOrDefault(c => c.Id == datum.Mother);
                character.Spouse = characterEntities.FirstOrDefault(c => c.Id == datum.Spouse);
                character.Allegiances = houseEntities.Where(h => datum.Allegiances.Contains(h.Id)).ToHashSet();
                character.Books = bookEntities.Where(b => datum.Books.Contains(b.Id)).ToHashSet();
                character.PovBooks = bookEntities.Where(b => datum.PovBooks.Contains(b.Id)).ToHashSet();
            }

            model.Entity<HouseEntity>().HasData(houseEntities);
            model.Entity<CharacterEntity>().HasData(characterEntities);
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
