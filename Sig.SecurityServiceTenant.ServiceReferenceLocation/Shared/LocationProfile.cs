using AutoMapper;
using Sig.SecurityServiceTenant.Domain.ValueObjects;
using Sig.SecurityServiceTenant.ServiceReferenceLocation.Dtos;

namespace Sig.SecurityServiceTenant.ServiceReferenceLocation.Features.City;

public class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<LocationDto, LocationReference>();
    }
}
