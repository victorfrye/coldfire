namespace VictorFrye.Coldfire.Api
{
    public interface IService<T>
    {
        public Task<IList<T>> Get();
        public Task<T?> Find(int id);
    }
}
