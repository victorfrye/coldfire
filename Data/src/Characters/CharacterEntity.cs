using VictorFrye.Coldfire.Data.Books;
using VictorFrye.Coldfire.Data.Houses;

namespace VictorFrye.Coldfire.Data.Characters;

public class CharacterEntity : BaseEntity
{
    public string? Gender { get; set; }
    public string? Culture { get; set; }
    public string? Born { get; set; }
    public string? Died { get; set; }
    public ISet<string> Titles { get; set; }
    public ISet<string> Aliases { get; set; }
    public CharacterEntity? Father { get; set; }
    public CharacterEntity? Mother { get; set; }
    public CharacterEntity? Spouse { get; set; }
    public ISet<HouseEntity> Allegiances { get; set; }
    public ISet<BookEntity> Books { get; set; }
    public ISet<BookEntity> PovBooks { get; set; }
    public ISet<string> TvSeries { get; set; }
    public ISet<string> PlayedBy { get; set; }

    public CharacterEntity()
    {
        Titles = new HashSet<string>();
        Aliases = new HashSet<string>();
        Allegiances = new HashSet<HouseEntity>();
        Books = new HashSet<BookEntity>();
        PovBooks = new HashSet<BookEntity>();
        TvSeries = new HashSet<string>();
        PlayedBy = new HashSet<string>();
    }

    public CharacterEntity(
        int id,
        string name,
        string? gender,
        string? culture,
        string? born,
        string? died,
        ISet<string> titles,
        ISet<string> aliases,
        CharacterEntity? father,
        CharacterEntity? mother,
        CharacterEntity? spouse,
        ISet<HouseEntity> allegiances,
        ISet<BookEntity> books,
        ISet<BookEntity> povBooks,
        ISet<string> tvSeries,
        ISet<string> playedBy)
    {
        Id = id;
        Name = name;
        Gender = gender;
        Culture = culture;
        Born = born;
        Died = died;
        Titles = titles ?? new HashSet<string>();
        Aliases = aliases ?? new HashSet<string>();
        Father = father;
        Mother = mother;
        Spouse = spouse;
        Allegiances = allegiances ?? new HashSet<HouseEntity>();
        Books = books ?? new HashSet<BookEntity>();
        PovBooks = povBooks ?? new HashSet<BookEntity>();
        TvSeries = tvSeries ?? new HashSet<string>();
        PlayedBy = playedBy ?? new HashSet<string>();
    }
}
