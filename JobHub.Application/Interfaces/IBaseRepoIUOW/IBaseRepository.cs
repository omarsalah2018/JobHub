namespace JobHub.Application.Interfaces.IBaseRepoIUOW
{
    public interface IBaseRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
    }
}
