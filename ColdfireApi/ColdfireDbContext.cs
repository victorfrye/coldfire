using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ColdfireApi
{
    public class ColdfireDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Character> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            var converter = new ValueConverter<ISet<string>, string>(
                v => string.Join(";", v),
                v => v.Split(new[] { ';' }).ToHashSet());

            model.Entity<Book>()
                .Property(b => b.Authors)
                .HasConversion(converter);

            model.Entity<Book>()
                .HasMany(b => b.Characters)
                .WithMany(c => c.Books)
                .UsingEntity(j => j.ToTable("BookCharacters"));

            model.Entity<Book>()
                .HasMany(b => b.PovCharacters)
                .WithMany(c => c.PovBooks)
                .UsingEntity(j => j.ToTable("BookPovCharacters"));

            model.Entity<House>()
                .Property(h => h.Titles)
                .HasConversion(converter);

            model.Entity<House>()
                .Property(h => h.Seats)
                .HasConversion(converter);

            model.Entity<House>()
                .Property<int?>("HouseCurrentLordForeignKey");

            model.Entity<House>()
                .HasOne(h => h.CurrentLord)
                .WithMany()
                .HasForeignKey("HouseCurrentLordForeignKey");

            model.Entity<House>()
                .Property<int?>("HouseHeirForeignKey");

            model.Entity<House>()
                .HasOne(h => h.Heir)
                .WithMany()
                .HasForeignKey("HouseHeirForeignKey");

            model.Entity<House>()
                .Property<int?>("HouseOverlordForeignKey");

            model.Entity<House>()
                .HasOne(h => h.Overlord)
                .WithMany()
                .HasForeignKey("HouseOverlordForeignKey");

            model.Entity<House>()
                .Property<int?>("HouseFounderForeignKey");

            model.Entity<House>()
                .HasOne(h => h.Founder)
                .WithMany()
                .HasForeignKey("HouseFounderForeignKey");

            model.Entity<House>()
                .Property(h => h.AncestralWeapons)
                .HasConversion(converter);

            model.Entity<House>()
                .HasMany(h => h.CadetBranches)
                .WithMany()
                .UsingEntity(j => j.ToTable("HouseCadetBranches"));

            model.Entity<House>()
                .HasMany(h => h.SwornMembers)
                .WithMany(c => c.Allegiances)
                .UsingEntity(j => j.ToTable("HouseSwornMembers"));

            model.Entity<Character>()
                .Property(h => h.Titles)
                .HasConversion(converter);

            model.Entity<Character>()
                .Property(h => h.Aliases)
                .HasConversion(converter);

            model.Entity<Character>()
                .Property<int?>("CharacterFatherForeignKey");

            model.Entity<Character>()
                .HasOne(c => c.Father)
                .WithMany()
                .HasForeignKey("CharacterFatherForeignKey");

            model.Entity<Character>()
                .Property<int?>("CharacterMotherForeignKey");

            model.Entity<Character>()
                .HasOne(c => c.Mother)
                .WithMany()
                .HasForeignKey("CharacterMotherForeignKey");

            model.Entity<Character>()
                .Property<int?>("CharacterSpouseForeignKey");

            model.Entity<Character>()
                .HasOne(c => c.Spouse)
                .WithMany()
                .HasForeignKey("CharacterSpouseForeignKey");

            model.Entity<Character>()
                .Property(h => h.TvSeries)
                .HasConversion(converter);

            model.Entity<Character>()
                .Property(h => h.PlayedBy)
                .HasConversion(converter);

            model.Entity<Character>().HasData(
                new Character(
                    id: 583,
                    name: "Jon Snow",
                    gender: "Male",
                    culture: "Northmen",
                    born: "In 283 AC",
                    died: null,
                    titles: new HashSet<string> { "Lord Commander of the Night's Watch" },
                    aliases: new HashSet<string>
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
                    father: null,
                    mother: null,
                    spouse: null,
                    allegiances: new HashSet<House>(),
                    books: new HashSet<Book>(),
                    povBooks: new HashSet<Book>(),
                    tvSeries: new HashSet<string>
                    {
                        "Season 1",
                        "Season 2",
                        "Season 3",
                        "Season 4",
                        "Season 5",
                        "Season 6"
                    },
                    playedBy: new HashSet<string> { "Kit Harington" }));

            base.OnModelCreating(model);
        }

        public ColdfireDbContext(DbContextOptions<ColdfireDbContext> options) : base(options) { }
    }
}
