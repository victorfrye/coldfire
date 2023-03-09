using VictorFrye.Coldfire.Data.Books;

namespace VictorFrye.Coldfire.Api.Books;

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Isbn { get; set; }
    public IList<string> Authors { get; set; }
    public int NumberOfPages { get; set; }
    public string? Publisher { get; set; }
    public string? Country { get; set; }
    public string? MediaType { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public IList<string> Characters { get; set; }
    public IList<string> PovCharacters { get; set; }

    public Book(BookEntity entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        Isbn = entity.Isbn;
        Authors = entity.Authors.ToList() ?? new List<string>();
        NumberOfPages = entity.NumberOfPages;
        Publisher = entity.Publisher;
        Country = entity.Country;
        MediaType = entity.MediaType;
        ReleaseDate = entity.Released;
        Characters = entity.Characters.Any() ? entity.Characters.Select(c => c.Name).ToList() : new List<string>();
        PovCharacters = entity.PovCharacters.Any() ? entity.PovCharacters.Select(c => c.Name).ToList() : new List<string>();
    }
}
