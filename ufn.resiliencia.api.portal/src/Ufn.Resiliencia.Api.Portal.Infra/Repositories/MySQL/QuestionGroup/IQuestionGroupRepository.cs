using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Shared;

using QuestionGroupDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.QuestionGroup;

namespace Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.QuestionGroup;
public interface IQuestionGroupRepository : IBaseRepository<QuestionGroupDomain>
{
    Task<bool> QuestionGroupHasQuestions(int id);
}
