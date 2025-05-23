using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sig.SecurityServiceTenant.Services.UseCases.Address;

public class CreateAddressCommand : IRequest<Result<CreateAddressResult>>
{
    public required string Street { get; set; }
    public required string Number { get; set; }
    public required string Complement { get; set; }
    public string? Reference { get; set; }
    public required string District { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string PostalCode { get; set; }
}
