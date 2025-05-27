using FluentResults;
using Sig.SecurityServiceTenant.Domain.ServiceReferenceLocation;
using Sig.SecurityServiceTenant.Domain.ValueObjects;

namespace Sig.SecurityServiceTenant.ServiceReferenceLocation.Features;

public class CountryClient : ICountryClient
{
    public Task<Result<LocationReference>> GetByCode(string code)
    {
        throw new NotImplementedException();
    }
    public Task<Result<LocationReference>> GetById(string code)
    {
        throw new NotImplementedException();
    }
}
