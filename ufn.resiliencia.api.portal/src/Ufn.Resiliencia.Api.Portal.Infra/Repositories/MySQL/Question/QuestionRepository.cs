using Dapper;

using Ufn.Resiliencia.Api.Portal.Infra.Data.MySql;
using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Shared;

using QuestionDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.Question;

namespace Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Question;
public class QuestionRepository : BaseRepository<QuestionDomain>, IQuestionRepository
{
    public QuestionRepository(MySqlContext defaultContext, MySqlDbSession session) : base(defaultContext, session)
    {
    }

    public async Task<bool> QuestionHasAnswers(int id)
    {
        var parameters = new
        {
            Id = id,
        };

        var result = await Session.Connection.QueryFirstOrDefaultAsync<int>(QuestionStatements.QuestionHasAnswers, parameters);

        return result > 0;
    }
}
