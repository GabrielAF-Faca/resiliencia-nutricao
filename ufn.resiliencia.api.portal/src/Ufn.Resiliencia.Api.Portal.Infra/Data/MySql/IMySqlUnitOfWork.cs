using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Answer;
using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Establishment;
using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.EstablishmentQuestionnaire;
using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Question;
using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.QuestionGroup;
using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Questionnaire;
using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.RespondentGroup;

namespace Ufn.Resiliencia.Api.Portal.Infra.Data.MySql;

public interface IMySqlUnitOfWork : IDisposable
{
    #region Repositories
    IAnswerRepository AnswerRepository { get; }
    IEstablishmentRepository EstablishmentRepository { get; }
    IEstablishmentQuestionnaireRepository EstablishmentQuestionnaireRepository { get; }
    IQuestionRepository QuestionRepository { get; }
    IQuestionGroupRepository QuestionGroupRepository { get; }
    IQuestionnaireRepository QuestionnaireRepository { get; }
    IRespondentGroupRepository RespondentGroupRepository { get; }
    #endregion

    void BeginTransaction();
    void CommitSession();
    Task CommitContextAsync();
    void Rollback();
}