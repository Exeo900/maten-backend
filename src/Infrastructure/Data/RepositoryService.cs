using Application.Recipes.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Data;
public class RepositoryService<T> : IRepositoryService<T> where T : Entity  
{
    private readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public RepositoryService(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task Create(T entity)
    {
        await _dbSet.AddAsync(entity);

        await _context.SaveChangesAsync();
    }

    public async Task<int> Delete(T entity)
    {
        _dbSet.Remove(entity);

        return await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.ToListAsync();
    }

    public async Task<T> GetById(Guid id, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<int> Update(T entity)
    {
        _dbSet.Update(entity);

        return await _context.SaveChangesAsync();
    }
}
