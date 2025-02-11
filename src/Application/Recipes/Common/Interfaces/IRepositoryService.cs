﻿using System.Linq.Expressions;

namespace Application.Recipes.Common.Interfaces;
public interface IRepositoryService<T>
{
    Task<T> GetById(Guid id, params Expression<Func<T, object>>[] includes);
    Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includes);
    Task Create(T entity);
    Task<int> Update(T entity);
    Task<int> Delete(T entity);
}