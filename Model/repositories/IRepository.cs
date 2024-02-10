namespace Model.repositories;

public interface IRepository<T>
{
    Task<IEnumerable<T>?> Read();
    Task Create(T entity);
    Task Delete(int id);
    Task Update(T entity, int id);
}
