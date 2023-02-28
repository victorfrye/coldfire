using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VictorFrye.Coldfire.Data.Books;
using VictorFrye.Coldfire.Data.Characters;
using VictorFrye.Coldfire.Data.Houses;

namespace VictorFrye.Coldfire.Data
{
    public class ColdfireDbContext : DbContext
    {
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<HouseEntity> Houses { get; set; }
        public DbSet<CharacterEntity> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            var converter = new ValueConverter<ISet<string>, string>(
                v => string.Join(";", v),
                v => v.Split(new[] { ';' }).ToHashSet());

            model.Entity<BookEntity>()
                .Property(b => b.Authors)
                .HasConversion(converter);

            model.Entity<BookEntity>()
                .HasMany(b => b.Characters)
                .WithMany(c => c.Books)
                .UsingEntity(j => j.ToTable("BookCharacters"));

            model.Entity<BookEntity>()
                .HasMany(b => b.PovCharacters)
                .WithMany(c => c.PovBooks)
                .UsingEntity(j => j.ToTable("BookPovCharacters"));

            model.Entity<HouseEntity>()
                .Property(h => h.Titles)
                .HasConversion(converter);

            model.Entity<HouseEntity>()
                .Property(h => h.Seats)
                .HasConversion(converter);

            model.Entity<HouseEntity>()
                .Property<int?>("HouseCurrentLordForeignKey");

            model.Entity<HouseEntity>()
                .HasOne(h => h.CurrentLord)
                .WithMany()
                .HasForeignKey("HouseCurrentLordForeignKey");

            model.Entity<HouseEntity>()
                .Property<int?>("HouseHeirForeignKey");

            model.Entity<HouseEntity>()
                .HasOne(h => h.Heir)
                .WithMany()
                .HasForeignKey("HouseHeirForeignKey");

            model.Entity<HouseEntity>()
                .Property<int?>("HouseOverlordForeignKey");

            model.Entity<HouseEntity>()
                .HasOne(h => h.Overlord)
                .WithMany()
                .HasForeignKey("HouseOverlordForeignKey");

            model.Entity<HouseEntity>()
                .Property<int?>("HouseFounderForeignKey");

            model.Entity<HouseEntity>()
                .HasOne(h => h.Founder)
                .WithMany()
                .HasForeignKey("HouseFounderForeignKey");

            model.Entity<HouseEntity>()
                .Property(h => h.AncestralWeapons)
                .HasConversion(converter);

            model.Entity<HouseEntity>()
                .HasMany(h => h.CadetBranches)
                .WithMany()
                .UsingEntity(j => j.ToTable("HouseCadetBranches"));

            model.Entity<HouseEntity>()
                .HasMany(h => h.SwornMembers)
                .WithMany(c => c.Allegiances)
                .UsingEntity(j => j.ToTable("HouseSwornMembers"));

            model.Entity<CharacterEntity>()
                .Property(h => h.Titles)
                .HasConversion(converter);

            model.Entity<CharacterEntity>()
                .Property(h => h.Aliases)
                .HasConversion(converter);

            model.Entity<CharacterEntity>()
                .Property<int?>("CharacterFatherForeignKey");

            model.Entity<CharacterEntity>()
                .HasOne(c => c.Father)
                .WithMany()
                .HasForeignKey("CharacterFatherForeignKey");

            model.Entity<CharacterEntity>()
                .Property<int?>("CharacterMotherForeignKey");

            model.Entity<CharacterEntity>()
                .HasOne(c => c.Mother)
                .WithMany()
                .HasForeignKey("CharacterMotherForeignKey");

            model.Entity<CharacterEntity>()
                .Property<int?>("CharacterSpouseForeignKey");

            model.Entity<CharacterEntity>()
                .HasOne(c => c.Spouse)
                .WithMany()
                .HasForeignKey("CharacterSpouseForeignKey");

            model.Entity<CharacterEntity>()
                .Property(h => h.TvSeries)
                .HasConversion(converter);

            model.Entity<CharacterEntity>()
                .Property(h => h.PlayedBy)
                .HasConversion(converter);

            /*            model.Entity<CharacterEntity>().HasData(
                            new CharacterEntity(
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
                                allegiances: new HashSet<HouseEntity>(),
                                books: new HashSet<BookEntity>(),
                                povBooks: new HashSet<BookEntity>(),
                                tvSeries: new HashSet<string>
                                {
                                    "Season 1",
                                    "Season 2",
                                    "Season 3",
                                    "Season 4",
                                    "Season 5",
                                    "Season 6"
                                },
                                playedBy: new HashSet<string> { "Kit Harington" }));*/

            base.OnModelCreating(model);
        }

        public ColdfireDbContext(DbContextOptions<ColdfireDbContext> options) : base(options) { }
    }
}
