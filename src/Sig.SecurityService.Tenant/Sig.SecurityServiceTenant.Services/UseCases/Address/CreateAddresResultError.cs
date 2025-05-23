using Sig.SecurityService.Tenant.Common.Results.CustomErrors;

namespace Sig.SecurityServiceTenant.Services.UseCases.Address
{
    public class CreateAddresResultError : CustomError
    {
        public const string AddressNotFoundCode = "001";

        public CreateAddresResultError(string typeError, Type sourceType, string code, string message) : base(typeError, sourceType, code, message)
        {
        }

        public static CreateAddresResultError AddressNotFound(Guid id)
            => new(AddressNotFoundCode, $"Address '{id}' not found");
    {
    }
}
