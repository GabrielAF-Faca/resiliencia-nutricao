using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Shared;

using QuestionnaireDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.Questionnaire;
using QuestionnaireBasicDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.QuestionnaireBasic;

namespace Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Questionnaire;
public interface IQuestionnaireRepository : IBaseRepository<QuestionnaireDomain>
{
    Task<bool> QuestionnaireHasQuestionsGroup(int id);
    Task<IEnumerable<QuestionnaireBasicDomain>> GetAllBasic();
    Task<IEnumerable<QuestionnaireBasicDomain>> GetAllBasicByEstablishment(int establishmentId);
    Task<QuestionnaireDomain?> GetCompleteById(int id);
}
