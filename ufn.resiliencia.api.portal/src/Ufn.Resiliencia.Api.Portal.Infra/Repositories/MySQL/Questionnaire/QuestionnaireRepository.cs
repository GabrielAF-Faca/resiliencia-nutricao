using Dapper;

using Ufn.Resiliencia.Api.Portal.Infra.Data.MySql;
using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Shared;

using QuestionnaireDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.Questionnaire;
using QuestionnaireBasicDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.QuestionnaireBasic;
using QuestionGroupDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.QuestionGroup;
using QuestionDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.Question;

using Microsoft.EntityFrameworkCore;
using Ufn.Resiliencia.Api.Portal.Domain.Entities;

namespace Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Questionnaire;
public class QuestionnaireRepository : BaseRepository<QuestionnaireDomain>, IQuestionnaireRepository
{
    public QuestionnaireRepository(MySqlContext defaultContext, MySqlDbSession session) : base(defaultContext, session)
    {
    }

    public async Task<IEnumerable<QuestionnaireBasicDomain>> GetAllBasic()
    {
        var result = await Session.Connection.QueryAsync<QuestionnaireBasicDomain>(QuestionnaireStatements.GetAllBasic);
        return result;
    }

    public async Task<IEnumerable<QuestionnaireBasicDomain>> GetAllBasicByEstablishment(int establishmentId)
    {
        var parameters = new
        {
            EstablishmentId = establishmentId,
        };

        var result = await Session.Connection.QueryAsync<QuestionnaireBasicDomain>(QuestionnaireStatements.GetAllBasicByEstablishment, parameters);
        return result;
    }

    public async Task<QuestionnaireDomain?> GetCompleteById(int id)
    {
        var result = await DbSet.Include(x => x.QuestionGroups)
                         .ThenInclude(x => x.Questions)
                         .Where(x => x.Id == id)
                         .FirstOrDefaultAsync();

        return result;
    }

    public async Task<bool> QuestionnaireHasQuestionsGroup(int id)
    {
        var parameters = new
        {
            Id = id,
        };

        var result = await Session.Connection.QueryFirstOrDefaultAsync<int>(QuestionnaireStatements.QuestionnaireHasQuestionsGroup, parameters);

        return result > 0;
    }
}
