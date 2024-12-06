using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Shared;

using EstablishmentDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.Establishment;

namespace Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Establishment;
public interface IEstablishmentRepository : IBaseRepository<EstablishmentDomain>
{
    Task<bool> EstablishmentHasQuestionnaires(int id);
}
