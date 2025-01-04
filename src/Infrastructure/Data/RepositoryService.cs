using Application.Recipes.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
public class RepositoryService<T> : IRepositoryService<T> where T : class
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

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

    public async Task Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task Update(T entity)
    {
        throw new NotImplementedException();
    }
}
