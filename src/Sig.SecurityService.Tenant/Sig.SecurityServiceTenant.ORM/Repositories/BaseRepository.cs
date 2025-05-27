using FluentResults;
using Microsoft.EntityFrameworkCore;
using Sig.SecurityService.Tenant.Common.FluentResults.CustomErrors;
using Sig.SecurityServiceTenant.Domain.Interfaces;

namespace Sig.SecurityServiceTenant.ORM.Repositories;

public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = context.Set<TEntity>();
    }

    public async Task<Result<TEntity>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _dbSet.FindAsync([id], cancellationToken);

    public async Task<Result<TEntity>> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        try
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            var changes = await _context.SaveChangesAsync(cancellationToken);

            return changes == 1 ? 
                Result.Ok(entity) : 
                ExceptionalFailure.Fail("No changes were persisted to the database");
        }
        catch (DbUpdateException ex)
        {
            return ExceptionalFailure.Fail("Failed to create entity in database", ex);
        }
        catch (Exception ex)
        {
            return ExceptionalFailure.Fail("Unexpected error while creating entity", ex);
        }
    }

    public async Task<Result<TEntity>> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        try
        {
            _dbSet.Update(entity);
            var changes = await _context.SaveChangesAsync(cancellationToken);

            return changes == 1 ?
                Result.Ok(entity) :
                ExceptionalFailure.Fail("No changes were persisted to the database");
        }       
        catch (DbUpdateConcurrencyException ex)
        {
            return ExceptionalFailure.Fail("Concurrency conflict during entity update", ex);
        }
        catch (DbUpdateException ex)
        {
            return ExceptionalFailure.Fail("Failed to update entity in database", ex);
        }
        catch (Exception ex)
        {
            return ExceptionalFailure.Fail("Unexpected error while updating entity", ex);
        }
    }

    public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var entity = await _dbSet.FindAsync([id], cancellationToken);
            if (entity == null)
                return ValidatorFailure.Fail($"Entity with ID {id} not found");

            _dbSet.Remove(entity);
            var changes = await _context.SaveChangesAsync(cancellationToken);

            return changes > 0
                ? Result.Ok()
                : ExceptionalFailure.Fail("No changes were persisted to the database");
        }
        catch (DbUpdateException ex)
        {
            return ExceptionalFailure.Fail("Failed to delete entity from database", ex);
        }
        catch (Exception ex)
        {
            return ExceptionalFailure.Fail("Unexpected error while deleting entity", ex);
        }
    }
}
