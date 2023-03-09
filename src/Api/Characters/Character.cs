using VictorFrye.Coldfire.Data.Characters;

namespace VictorFrye.Coldfire.Api.Characters;

public class Character
{
    public int Id { get; set; }
    public string Name { get; set; }
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
        Father = entity.Father?.Name;
        Mother = entity.Mother?.Name;
        Spouse = entity.Spouse?.Name;
        Allegiances = entity.Allegiances.Any() ? entity.Allegiances.Select(a => a.Name).ToList() : new List<string>();
        Books = entity.Books.Any() ? entity.Books.Select(b => b.Name).ToList() : new List<string>();
        PovBooks = entity.PovBooks.Any() ? entity.PovBooks.Select(b => b.Name).ToList() : new List<string>();
        TvSeries = entity.TvSeries.ToList() ?? new List<string>();
        PlayedBy = entity.PlayedBy.ToList() ?? new List<string>();
    }
}
