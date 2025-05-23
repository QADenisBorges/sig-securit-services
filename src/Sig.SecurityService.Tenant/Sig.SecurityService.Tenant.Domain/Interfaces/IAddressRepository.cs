using Sig.SecurityServiceTenant.Domain.ValueObjects;

namespace Sig.SecurityServiceTenant.Domain.Interfaces;

public interface IAddressRepository : IBaseRepository<Address>
{
    Task<Address> GetByIdAsync(Guid id);
    Task<IEnumerable<Address>> GetAllAsync();
    Task<Address> AddAsync(Address address);
    Task<Address> UpdateAsync(Address address);
    Task<bool> DeleteAsync(Guid id);
}