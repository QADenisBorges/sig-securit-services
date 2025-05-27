using FluentResults;

namespace Sig.SecurityServiceTenant.Domain.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    Task<Result<TEntity>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<TEntity>> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<Result<TEntity>> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
