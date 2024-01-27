namespace BookSystem.App.Managers
{
    public interface IManager<T> : IEnumerable<T>
        where T : class
    {
        void Add(T entity);
        void Remove(T entity);
    }
}
