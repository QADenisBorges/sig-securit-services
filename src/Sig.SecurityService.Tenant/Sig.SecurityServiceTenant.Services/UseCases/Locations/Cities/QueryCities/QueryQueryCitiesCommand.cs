namespace Sig.SecurityServiceTenant.Services.UseCases.Locations.Cities.QueryCity;

public class QueryQueryCitiesCommand
{
    public required string City { get; set; }
    public required string State { get; set; }
    public required string Country { get; set; }
}
