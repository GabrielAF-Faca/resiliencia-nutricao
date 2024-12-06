using Ufn.Resiliencia.Api.Portal.Domain.Entities.Shared;

namespace Ufn.Resiliencia.Api.Portal.Domain.Entities;
public class Establishment : BaseEntity
{
    public string Name { get; set; }
    public string ZipCode { get; set; }
    public string Street { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Number { get; set; }
    public string? Complement { get; set; }
    public bool Active { get; set; }
}
