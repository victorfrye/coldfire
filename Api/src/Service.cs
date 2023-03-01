using VictorFrye.Coldfire.Data;

namespace VictorFrye.Coldfire.Api
{

    public abstract class Service<T> : IService<T>
    {
        protected readonly ColdfireDbContext _db;

        public Service(ColdfireDbContext db)
        {
            _db = db;
        }

        public abstract Task<IList<T>> Get();
        public abstract Task<T?> Find(int id);
    }
}
