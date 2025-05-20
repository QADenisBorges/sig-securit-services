using FluentResults;
using Microsoft.EntityFrameworkCore;
using Sig.SecurityServiceTenant.Domain.Interfaces;

namespace Sig.SecurityServiceTenant.ORM.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<Result<T>> GetByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null)
            return Result.Fail<T>("Entity not found.");

        return Result.Ok(entity);
    }

    public async Task<Result> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        var saved = await _context.SaveChangesAsync() > 0;
        return saved ? Result.Ok() : Result.Fail("Failed to save entity.");
    }

    public async Task<Result> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        var saved = await _context.SaveChangesAsync() > 0;
        return saved ? Result.Ok() : Result.Fail("Failed to update entity.");
    }
}
