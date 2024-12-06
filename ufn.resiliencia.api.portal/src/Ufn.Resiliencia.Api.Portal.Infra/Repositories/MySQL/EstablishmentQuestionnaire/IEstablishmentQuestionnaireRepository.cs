using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Shared;

using EstablishmentQuestionnaireDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.EstablishmentQuestionnaire;

namespace Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.EstablishmentQuestionnaire;
public interface IEstablishmentQuestionnaireRepository : IBaseRepository<EstablishmentQuestionnaireDomain>
{
}
