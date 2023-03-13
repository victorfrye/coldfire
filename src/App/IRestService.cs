namespace VictorFrye.Coldfire.App
{
    public interface IRestService<T>
    {
        public Task<T> SendGet(int id);
    }
}
