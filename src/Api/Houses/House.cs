using Newtonsoft.Json;
using VictorFrye.Coldfire.Api.Characters;
using VictorFrye.Coldfire.Data.Houses;

namespace VictorFrye.Coldfire.Api.Houses;

public class House
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Region { get; set; }
    public string? CoatOfArms { get; set; }
    public string? Words { get; set; }
    public IList<string> Titles { get; set; }
    public IList<string> Seats { get; set; }
    public string? CurrentLord { get; set; }
    public string? Heir { get; set; }
    public string? Overlord { get; set; }
    public string? Founded { get; set; }
    public string? Founder { get; set; }
    public string? DiedOut { get; set; }
    public IList<string> AncestralWeapons { get; set; }
    public IList<string> CadetBranches { get; set; }

    public IList<string> SwornMembers { get; set; }

    public House(HouseEntity entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        Region = entity.Region;
        CoatOfArms = entity.CoatOfArms;
        Words = entity.Words;
        Titles = entity.Titles.ToList() ?? new List<string>();
        Seats = entity.Seats.ToList() ?? new List<string>();
        CurrentLord = entity.CurrentLord != null ? Character.GetDisplayName(entity.CurrentLord) : null;
        Heir = entity.Heir != null ? Character.GetDisplayName(entity.Heir) : null;
        Overlord = entity.Overlord?.Name;
        Founded = entity.Founded;
        Founder = entity.Founder != null ? Character.GetDisplayName(entity.Founder) : null;
        DiedOut = entity.DiedOut;
        AncestralWeapons = entity.AncestralWeapons.ToList() ?? new List<string>();
        CadetBranches = entity.CadetBranches.Any() ? entity.CadetBranches.Select(h => h.Name).ToList() : new List<string>();
        SwornMembers = entity.SwornMembers.Any() ? entity.SwornMembers.Select(c => Character.GetDisplayName(c)).ToList() : new List<string>();
    }

    public override string ToString() => JsonConvert.ToString(this);
}
