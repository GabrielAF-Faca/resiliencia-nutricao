using System.Diagnostics.CodeAnalysis;

using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Answer;
using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Establishment;
using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.EstablishmentQuestionnaire;
using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Question;
using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.QuestionGroup;
using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Questionnaire;
using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.RespondentGroup;

namespace Ufn.Resiliencia.Api.Portal.Infra.Data.MySql;

[ExcludeFromCodeCoverage]
public class MySqlUnitOfWork : IMySqlUnitOfWork
{
    #region Constructor
    private readonly MySqlDbSession _dbSession;
    private readonly MySqlContext _context;

    public MySqlUnitOfWork(MySqlDbSession dbSession, MySqlContext context)
    {
        _dbSession = dbSession;
        _context = context;
    }
    #endregion

    #region Repositories
    public IAnswerRepository AnswerRepository => new AnswerRepository(_context, _dbSession);
    public IEstablishmentRepository EstablishmentRepository => new EstablishmentRepository(_context, _dbSession);
    public IEstablishmentQuestionnaireRepository EstablishmentQuestionnaireRepository => new EstablishmentQuestionnaireRepository(_context, _dbSession);
    public IQuestionRepository QuestionRepository => new QuestionRepository(_context, _dbSession);
    public IQuestionGroupRepository QuestionGroupRepository => new QuestionGroupRepository(_context, _dbSession);
    public IQuestionnaireRepository QuestionnaireRepository => new QuestionnaireRepository(_context, _dbSession);
    public IRespondentGroupRepository RespondentGroupRepository => new RespondentGroupRepository(_context, _dbSession);
    #endregion

    #region Implementation
    public void BeginTransaction()
    {
        _dbSession.Transaction = _dbSession.Connection.BeginTransaction();
    }

    public void CommitSession()
    {
        _dbSession?.Transaction?.Commit();
    }

    public async Task CommitContextAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Rollback()
    {
        _dbSession?.Transaction?.Rollback();
    }

    public void Dispose()
    {
        _dbSession?.Dispose();
        _dbSession?.Transaction?.Dispose();
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
    #endregion
}