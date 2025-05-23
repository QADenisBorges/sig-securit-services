using FluentResults;

namespace Sig.SecurityServiceTenant.Domain.Interfaces;

public interface IBaseRepository<T> where T : class
{
    public Task<Result<T>> GetByIdAsync(Guid id);
    public Task<Result<bool>> ExistsAsync(Guid id, CancellationToken cancellationToken);
    public Task<Result> AddAsync(T entity, CancellationToken cancellationToken);
    public Task<Result> UpdateAsync(T entity);
}
