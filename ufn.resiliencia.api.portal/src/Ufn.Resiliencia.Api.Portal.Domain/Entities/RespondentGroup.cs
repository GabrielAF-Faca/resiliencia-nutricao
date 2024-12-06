using Ufn.Resiliencia.Api.Portal.Domain.Entities.Shared;
using Ufn.Resiliencia.Api.Portal.Domain.Extensions;

namespace Ufn.Resiliencia.Api.Portal.Domain.Entities;

public class RespondentGroup : BaseEntity
{
    public string Description { get; set; }
    public bool Active { get; set; }
}
