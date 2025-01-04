namespace Application.Recipes.Common.Interfaces;
public interface IRepositoryService<T>
{
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}