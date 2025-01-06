namespace Application.Recipes.Common.Interfaces;
public interface IRepositoryService<T>
{
    Task<T> GetById(Guid id);
    Task<IEnumerable<T>> GetAll();
    Task Create(T entity);
    Task Update(T entity);
    Task<int> Delete(T entity);
}