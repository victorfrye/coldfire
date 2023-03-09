using VictorFrye.Coldfire.Data.Characters;

namespace VictorFrye.Coldfire.Data.Houses;

public class HouseEntity : BaseEntity
{
    public string? Region { get; set; }
    public string? CoatOfArms { get; set; }
    public string? Words { get; set; }
    public ISet<string> Titles { get; set; }
    public ISet<string> Seats { get; set; }
    public CharacterEntity? CurrentLord { get; set; }
    public CharacterEntity? Heir { get; set; }
    public HouseEntity? Overlord { get; set; }
    public string? Founded { get; set; }
    public CharacterEntity? Founder { get; set; }
    public string? DiedOut { get; set; }
    public ISet<string> AncestralWeapons { get; set; }
    public ISet<HouseEntity> CadetBranches { get; set; }

    public ISet<CharacterEntity> SwornMembers { get; set; }



    public HouseEntity()
    {
        Titles = new HashSet<string>();
        Seats = new HashSet<string>();
        AncestralWeapons = new HashSet<string>();
        CadetBranches = new HashSet<HouseEntity>();
        SwornMembers = new HashSet<CharacterEntity>();
    }

    public HouseEntity(
        int id,
        string name,
        string region,
        string coatOfArms,
        string words,
        ISet<string> titles,
        ISet<string> seats,
        CharacterEntity? currentLord,
        CharacterEntity? heir,
        HouseEntity? overlord,
        string founded,
        CharacterEntity? founder,
        string diedOut,
        ISet<string> ancestralWeapons,
        ISet<HouseEntity> cadetBranches,
        ISet<CharacterEntity> swornMembers)
    {
        Id = id;
        Name = name;
        Region = region;
        CoatOfArms = coatOfArms;
        Words = words;
        Titles = titles ?? new HashSet<string>();
        Seats = seats ?? new HashSet<string>();
        CurrentLord = currentLord;
        Heir = heir;
        Overlord = overlord;
        Founded = founded;
        Founder = founder;
        DiedOut = diedOut;
        AncestralWeapons = ancestralWeapons ?? new HashSet<string>();
        CadetBranches = cadetBranches ?? new HashSet<HouseEntity>();
        SwornMembers = swornMembers ?? new HashSet<CharacterEntity>();
    }

    public HouseEntity(HouseDto dto)
    {
        Id = dto.Id;
        Name = dto.Name;
        Region = dto.Region;
        CoatOfArms = dto.CoatOfArms;
        Words = dto.Words;
        Titles = dto.Titles.ToHashSet() ?? new HashSet<string>();
        Seats = dto.Seats.ToHashSet() ?? new HashSet<string>();
        Founded = dto.Founded;
        DiedOut = dto.DiedOut;
        AncestralWeapons = dto.AncestralWeapons.ToHashSet() ?? new HashSet<string>();
        CadetBranches = new HashSet<HouseEntity>();
        SwornMembers = new HashSet<CharacterEntity>();
    }
}
