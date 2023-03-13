using Microsoft.EntityFrameworkCore;
using VictorFrye.Coldfire.Data;
using VictorFrye.Coldfire.Data.Books;

namespace VictorFrye.Coldfire.Api.Books
{
    public class BookService : Service<Book>
    {
        public BookService(ColdfireDbContext db) : base(db) { }

        public override async Task<IList<Book>> Get()
        {
            var entities = await _db.Books.ToListAsync();

            return entities.Select(e => new Book(e)).ToList();
        }

        public override async Task<Book?> Find(int id)
        {
            var entity = await _db.Books.FindAsync(id);

            return entity is not null ? new Book(entity) : null;
        }
    }
}
