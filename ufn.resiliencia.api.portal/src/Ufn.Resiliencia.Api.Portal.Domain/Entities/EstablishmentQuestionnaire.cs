using Ufn.Resiliencia.Api.Portal.Domain.Entities.Shared;

namespace Ufn.Resiliencia.Api.Portal.Domain.Entities;
public class EstablishmentQuestionnaire : BaseEntity
{
    public int IdEstablishment { get; set; }
    public int IdQuestionnaire { get; set; }
    public bool Active { get; set; }
}