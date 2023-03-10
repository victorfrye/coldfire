namespace VictorFrye.Coldfire.App
{
    public interface IService<T>
    {
        public T Find(int id);
    }
}
