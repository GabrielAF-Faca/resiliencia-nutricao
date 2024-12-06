using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Shared;

using QuestionDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.Question;

namespace Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Question;
public interface IQuestionRepository : IBaseRepository<QuestionDomain>
{
    Task<bool> QuestionHasAnswers(int id);
}
