using Application.Recipes.Common.Interfaces;
using Domain.Entities;

namespace Infrastructure.Data;
public class RepositoryService<T> : IRepositoryService<T>
{
    public void Add(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAll()
    {
        if (typeof(T) == typeof(Recipe))
        {
            var recipes = new List<Recipe>
            {
                new Recipe { Id = Guid.NewGuid(), Name = "Pancakes" },
                new Recipe { Id = Guid.NewGuid(), Name = "Omelette" }
            };

            return Task.FromResult(recipes.Cast<T>());
        }

        throw new NotImplementedException();
    }

    public Task<T> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }
}
