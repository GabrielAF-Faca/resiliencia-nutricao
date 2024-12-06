using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Shared;

using static Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Answer.AnswerRepository;

using AnswerDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.Answer;

namespace Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Answer;
public interface IAnswerRepository : IBaseRepository<AnswerDomain>
{
    Task<IEnumerable<AnswerWithQuestionDescriptionDto>> GetAnswersByQuestionnaireIdAsync(int id);

    Task<IEnumerable<AnswerWithQuestionDescriptionDto>> GetAnswersByEstablishmentQuestionnaireAsync(int idEstablishment, int idQuestionnaire);

    Task<IEnumerable<AnswerWithQuestionDescriptionDto>> GetAllAnswersAsync();
}
