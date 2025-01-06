using Application.Recipes.Common.Interfaces;
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

    public async Task<int> Delete(T entity)
    {
        _dbSet.Remove(entity);

        return await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetById(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task Update(T entity)
    {
        throw new NotImplementedException();
    }
}
