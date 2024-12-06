using Dapper;

using Ufn.Resiliencia.Api.Portal.Infra.Data.MySql;
using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Shared;

using EstablishmentDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.Establishment;
namespace Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Establishment;
public class EstablishmentRepository : BaseRepository<EstablishmentDomain>, IEstablishmentRepository
{
    public EstablishmentRepository(MySqlContext defaultContext, MySqlDbSession session) : base(defaultContext, session)
    {
    }

    public async Task<bool> EstablishmentHasQuestionnaires(int id)
    {
        var parameters = new
        {
            Id = id,
        };

        var result = await Session.Connection.QueryFirstOrDefaultAsync<int>(EstablishmentStatements.EstablishmentHasQuestionnaires, parameters);

        return result > 0;
    }
}
