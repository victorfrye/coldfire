namespace VictorFrye.Coldfire.Data.Characters;

public class Character
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Gender { get; set; }
    public string? Culture { get; set; }
    public string? Born { get; set; }
    public string? Died { get; set; }
    public IList<string> Titles { get; set; }
    public IList<string> Aliases { get; set; }
    public string? Father { get; set; }
    public string? Mother { get; set; }
    public string? Spouse { get; set; }
    public IList<string> Allegiances { get; set; }
    public IList<string> Books { get; set; }
    public IList<string> PovBooks { get; set; }
    public IList<string> TvSeries { get; set; }
    public IList<string> PlayedBy { get; set; }

    public Character(
        int id,
        string name,
        string gender,
        string culture,
        string born,
        string died,
        IList<string> titles,
        IList<string> aliases,
        string father,
        string mother,
        string spouse,
        IList<string> allegiances,
        IList<string> books,
        IList<string> povBooks,
        IList<string> tvSeries,
        IList<string> playedBy)
    {
        Id = id;
        Name = name;
        Gender = gender;
        Culture = culture;
        Born = born;
        Died = died;
        Titles = titles;
        Aliases = aliases;
        Father = father;
        Mother = mother;
        Spouse = spouse;
        Allegiances = allegiances;
        Books = books;
        PovBooks = povBooks;
        TvSeries = tvSeries;
        PlayedBy = playedBy;
    }

    public Character(CharacterEntity entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        Gender = entity.Gender;
        Culture = entity.Culture;
        Born = entity.Born;
        Died = entity.Died;
        Titles = entity.Titles.ToList() ?? new List<string>();
        Aliases = entity.Aliases.ToList() ?? new List<string>();
        Father = entity.Father != null ? GetDisplayName(entity.Father) : null;
        Mother = entity.Mother != null ? GetDisplayName(entity.Mother) : null;
        Spouse = entity.Spouse != null ? GetDisplayName(entity.Spouse) : null;
        Allegiances = entity.Allegiances.Any() ? entity.Allegiances.Select(a => a.Name).ToList() : new List<string>();
        Books = entity.Books.Any() ? entity.Books.Select(b => b.Name).ToList() : new List<string>();
        PovBooks = entity.PovBooks.Any() ? entity.PovBooks.Select(b => b.Name).ToList() : new List<string>();
        TvSeries = entity.TvSeries.ToList() ?? new List<string>();
        PlayedBy = entity.PlayedBy.ToList() ?? new List<string>();
    }

    public static string GetDisplayName(CharacterEntity character) => string.IsNullOrWhiteSpace(character.Name) ? character.Name : character.Aliases.First();
}
