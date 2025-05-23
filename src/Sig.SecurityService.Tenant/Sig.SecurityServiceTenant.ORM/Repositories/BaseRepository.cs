using FluentResults;
using Microsoft.EntityFrameworkCore;
using Sig.SecurityService.Tenant.Common.Results.CustomErrors;
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
        try
        {
            var entity = await _dbSet.FindAsync(id);
            return entity is null
                ? new ExceptionError($"{typeof(T).Name} not found.")
                : Result.Ok(entity);
        }
        catch (Exception ex)
        {
            return new ExceptionError(ex);
        }
    }

    public async Task<Result> AddAsync(T entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            var saved = await _context.SaveChangesAsync() > 0;

            return saved
                ? Result.Ok()
                : Result.Fail(new Error($"Failed to save {typeof(T).Name}."));
        }
        catch (Exception ex)
        {
            return Result.Fail(new ExceptionalError(ex));
        }
    }

    public async Task<Result> UpdateAsync(T entity)
    {
        try
        {
            _dbSet.Update(entity);
            var saved = await _context.SaveChangesAsync() > 0;

            return saved
                ? Result.Ok()
                : Result.Fail(new Error($"Failed to update {typeof(T).Name}."));
        }
        catch (Exception ex)
        {
            return Result.Fail(new ExceptionalError(ex));
        }
    }
}
