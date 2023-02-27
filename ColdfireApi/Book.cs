namespace ColdfireApi
{
    public class Book
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Isbn { get; set; }
        public ISet<string> Authors { get; set; }
        public int NumberOfPages { get; set; }
        public string? Publisher { get; set; }
        public string? Country { get; set; }
        public string? MediaType { get; set; }
        public string? Released { get; set; }
        public ISet<Character> Characters { get; set; }
        public ISet<Character> PovCharacters { get; set; }

        public Book(
            int id,
            string slug,
            string url,
            string name,
            string isbn,
            ISet<string> authors,
            int numberOfPages,
            string? publisher,
            string? country,
            string? mediaType,
            string? released,
            ISet<Character> characters,
            ISet<Character> povCharacters)
        {
            Id = id;
            Slug = slug;
            Url = url;
            Name = name;
            Isbn = isbn;
            Authors = authors ?? new HashSet<string>();
            NumberOfPages = numberOfPages;
            Publisher = publisher;
            Country = country;
            MediaType = mediaType;
            Released = released;
            Characters = characters ?? new HashSet<Character>();
            PovCharacters = povCharacters ?? new HashSet<Character>();
        }
    }
}
