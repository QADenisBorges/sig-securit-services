using FluentResults;
using Sig.SecurityServiceTenant.Domain.ServiceReferenceLocation;
using Sig.SecurityServiceTenant.Domain.ValueObjects;

namespace Sig.SecurityServiceTenant.ServiceReferenceLocation.Features;

public class CityClient : ICityClient
{
    public Task<Result<LocationReference>> GetByCode(string code)
    {
        throw new NotImplementedException();
    }

    public Task<Result<LocationReference>> Query(string value)
    {
        throw new NotImplementedException();
    }
}
