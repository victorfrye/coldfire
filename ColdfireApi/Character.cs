namespace ColdfireApi
{
    public class Character
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Url { get; }
        public string Name { get; set; }
        public string? Gender { get; set; }
        public string? Culture { get; set; }
        public string? Born { get; set; }
        public string? Died { get; set; }
        public ISet<string> Titles { get; set; }

        public ISet<string> Aliases { get; set; }
        public Character? Father { get; set; }
        public Character? Mother { get; set; }
        public Character? Spouse { get; set; }
        public ISet<House> Allegiances { get; set; }
        public ISet<Book> Books { get; set; }
        public ISet<Book> PovBooks { get; set; }
        public ISet<string> TvSeries { get; set; }
        public ISet<string> PlayedBy { get; set; }

        public Character(
            int id,
            string name,
            string? gender,
            string? culture,
            string? born,
            string? died,
            ISet<string> titles,
            ISet<string> aliases,
            Character? father,
            Character? mother,
            Character? spouse,
            ISet<House> allegiances,
            ISet<Book> books,
            ISet<Book> povBooks,
            ISet<string> tvSeries,
            ISet<string> playedBy)
        {
            Id = id;
            Slug = name.Replace(" ", "-").ToLower();
            Url = String.Empty;
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
            Allegiances = allegiances ?? new HashSet<House>();
            Books = books ?? new HashSet<Book>();
            PovBooks = povBooks ?? new HashSet<Book>();
            TvSeries = tvSeries ?? new HashSet<string>();
            PlayedBy = playedBy ?? new HashSet<string>();
        }
    }
}
