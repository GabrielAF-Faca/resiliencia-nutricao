using Ufn.Resiliencia.Api.Portal.Infra.Data.MySql;
using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Shared;

using EstablishmentQuestionnaireDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.EstablishmentQuestionnaire;

namespace Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.EstablishmentQuestionnaire;
internal class EstablishmentQuestionnaireRepository : BaseRepository<EstablishmentQuestionnaireDomain>, IEstablishmentQuestionnaireRepository
{
    public EstablishmentQuestionnaireRepository(MySqlContext defaultContext, MySqlDbSession session) : base(defaultContext, session)
    {
    }
}
