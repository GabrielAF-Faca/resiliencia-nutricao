using Ufn.Resiliencia.Api.Portal.Application.Dto.Shared;

namespace Ufn.Resiliencia.Api.Portal.Application.Dto.Establishment;
public class EstablishmentCreateDto : BaseDto
{
    public string Name { get; set; }
    public string ZipCode { get; set; }
    public string Neighborhood { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Number { get; set; }
    public string? Complement { get; set; }
}
