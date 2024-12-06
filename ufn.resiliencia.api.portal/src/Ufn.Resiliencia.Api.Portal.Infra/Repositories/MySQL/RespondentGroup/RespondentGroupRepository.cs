using Dapper;

using Ufn.Resiliencia.Api.Portal.Infra.Data.MySql;
using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Shared;

using RespondentGroupDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.RespondentGroup;

namespace Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.RespondentGroup;
public class RespondentGroupRepository : BaseRepository<RespondentGroupDomain>, IRespondentGroupRepository
{
    public RespondentGroupRepository(MySqlContext defaultContext, MySqlDbSession session) : base(defaultContext, session)
    {
    }

    public async Task<bool> RespondentGroupHasQuestionnaires(int id)
    {
        var parameters = new
        {
            Id = id,
        };

        var result = await Session.Connection.QueryFirstOrDefaultAsync<int>(RespondentGroupStatements.RespondentGroupHasQuestionnaires, parameters);

        return result > 0;
    }
}
