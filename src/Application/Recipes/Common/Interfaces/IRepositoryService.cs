namespace Application.Recipes.Common.Interfaces;
public interface IRepositoryService<T>
{
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}