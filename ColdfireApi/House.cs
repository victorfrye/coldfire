using System.Diagnostics.Metrics;

namespace ColdfireApi
{
    public class House
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Region { get; set; }
        public string? CoatOfArms { get; set; }
        public string? Words { get; set; }
        public ISet<string> Titles { get; set; }
        public ISet<string> Seats { get; set; }
        public Character? CurrentLord { get; set; }
        public Character? Heir { get; set; }
        public House? Overlord { get; set; }
        public string? Founded { get; set; }
        public Character? Founder { get; set; }
        public string? DiedOut { get; set; }
        public ISet<string> AncestralWeapons { get; set; }
        public ISet<House> CadetBranches { get; set; }

        public ISet<Character> SwornMembers { get; set; }

        public House()
        {
            Titles = new HashSet<string>();
            Seats = new HashSet<string>();
            AncestralWeapons = new HashSet<string>();
            CadetBranches = new HashSet<House>();
            SwornMembers = new HashSet<Character>();
        }

        public House(
            int id,
            string name,
            string region,
            string coatOfArms,
            string words,
            ISet<string> titles,
            ISet<string> seats,
            Character currentLord,
            Character heir,
            House overlord,
            string founded,
            Character founder,
            string diedOut,
            ISet<string> ancestralWeapons,
            ISet<House> cadetBranches,
            ISet<Character> swornMembers)
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
            CadetBranches = cadetBranches ?? new HashSet<House>();
            SwornMembers = swornMembers ?? new HashSet<Character>();
        }
    }
}
