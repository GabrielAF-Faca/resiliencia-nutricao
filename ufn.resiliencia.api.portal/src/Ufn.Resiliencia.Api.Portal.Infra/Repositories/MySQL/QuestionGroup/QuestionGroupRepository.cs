using Dapper;

using Ufn.Resiliencia.Api.Portal.Infra.Data.MySql;
using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Shared;

using QuestionGroupDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.QuestionGroup;

namespace Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.QuestionGroup;
public class QuestionGroupRepository : BaseRepository<QuestionGroupDomain>, IQuestionGroupRepository
{
    public QuestionGroupRepository(MySqlContext defaultContext, MySqlDbSession session) : base(defaultContext, session)
    {
    }

    public async Task<bool> QuestionGroupHasQuestions(int id)
    {
        var parameters = new
        {
            Id = id,
        };

        var result = await Session.Connection.QueryFirstOrDefaultAsync<int>(QuestionGroupStatements.QuestionGroupHasQuestions, parameters);

        return result > 0;
    }
}
