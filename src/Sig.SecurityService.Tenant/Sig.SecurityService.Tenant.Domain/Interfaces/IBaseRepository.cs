using FluentResults;

namespace Sig.SecurityServiceTenant.Domain.Interfaces;

public interface IBaseRepository<T> where T : class
{
    public Task<Result<T>> GetByIdAsync(Guid id);
    public Task<Result> AddAsync(T entity);
    public Task<Result> UpdateAsync(T entity);
}
