using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Shared;

using RespondentGroupDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.RespondentGroup;

namespace Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.RespondentGroup;
public interface IRespondentGroupRepository : IBaseRepository<RespondentGroupDomain>
{
    Task<bool> RespondentGroupHasQuestionnaires(int id);
}
