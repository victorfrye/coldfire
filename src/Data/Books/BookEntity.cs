using VictorFrye.Coldfire.Data.Characters;

namespace VictorFrye.Coldfire.Data.Books;

public class BookEntity : BaseEntity
{
    public string Isbn { get; set; }
    public ISet<string> Authors { get; set; }
    public int NumberOfPages { get; set; }
    public string? Publisher { get; set; }
    public string? Country { get; set; }
    public string? MediaType { get; set; }
    public DateTime? Released { get; set; }
    public ISet<CharacterEntity> Characters { get; set; }
    public ISet<CharacterEntity> PovCharacters { get; set; }

    public BookEntity()
    {
        Authors = new HashSet<string>();
        Characters = new HashSet<CharacterEntity>();
        PovCharacters = new HashSet<CharacterEntity>();
    }

    public BookEntity(
        int id,
        string name,
        string isbn,
        ISet<string> authors,
        int numberOfPages,
        string? publisher,
        string? country,
        string? mediaType,
        DateTime? released,
        ISet<CharacterEntity> characters,
        ISet<CharacterEntity> povCharacters)
    {
        Id = id;
        Name = name;
        Isbn = isbn;
        Authors = authors ?? new HashSet<string>();
        NumberOfPages = numberOfPages;
        Publisher = publisher;
        Country = country;
        MediaType = mediaType;
        Released = released;
        Characters = characters ?? new HashSet<CharacterEntity>();
        PovCharacters = povCharacters ?? new HashSet<CharacterEntity>();
    }
}
