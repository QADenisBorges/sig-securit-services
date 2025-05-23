using AutoMapper;
using Sig.SecurityServiceTenant.Domain.Entities;
using Sig.SecurityServiceTenant.Domain.Enuns;
using Sig.SecurityServiceTenant.Domain.ObjectValues;
using Sig.SecurityServiceTenant.Domain.UseCases.Tenants.CreateTenant;
using Sig.SecurityServiceTenant.Domain.ValueObjects;

public class RegisterTenantProfile : Profile
{
    public RegisterTenantProfile()
    {
        CreateMap<CreateTenantCommand, Address>();

        CreateMap<CreateTenantCommand, Tenant>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Document, opt => opt.MapFrom(src => new Document { Number = src.Document }))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => new Email(src.Email)))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => new Phone(src.DddPhone, src.Phone)))
            .ForMember(dest => dest.WhatsappPhone, opt => opt.MapFrom(src =>
                src.DddWhatsappPhone.HasValue && src.WhatsappPhone.HasValue
                    ? new Phone(src.DddWhatsappPhone.Value, src.WhatsappPhone.Value)
                    : new Phone(src.DddPhone, src.Phone)))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(_ => true))
            .ForMember(dest => dest.SubscriptionStatus, opt => opt.MapFrom(_ => SubscriptionStatus.Active))
            .ForMember(dest => dest.Plan, opt => opt.Ignore());
    }
}
