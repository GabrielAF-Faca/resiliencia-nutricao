using Dapper;

using Microsoft.EntityFrameworkCore;

using Ufn.Resiliencia.Api.Portal.Infra.Data.MySql;
using Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Shared;

using AnswerDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.Answer;

namespace Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Answer
{
    public class AnswerRepository : BaseRepository<AnswerDomain>, IAnswerRepository
    {
        private readonly MySqlContext _defaultContext;
        private readonly MySqlDbSession _session;
        public AnswerRepository(MySqlContext defaultContext, MySqlDbSession session) : base(defaultContext, session)
        {
            _defaultContext = defaultContext;
            _session = session;
        }
        public class AnswerWithQuestionDescriptionDto
        {
            public int Id { get; set; }
            public int IdEstablishment { get; set; }
            public int IdQuestion { get; set; }
            public string UniqueCode { get; set; }
            public bool? QuestionOneAnswered { get; set; }
            public bool? QuestionTwoAnswered { get; set; }
            public bool? QuestionThreeAnswered { get; set; }
            public bool? AdditionalQuestionAnswered { get; set; }
            public string QuestionDescription { get; set; }
            public string EstablishmentName { get; set; } // Nova propriedade para o nome do estabelecimento
            public string QuestionnaireName { get; set; } // Nova propriedade para o nome do questionário
        }

        public Task<bool> EstablishmentHasQuestionnaires(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AnswerWithQuestionDescriptionDto>> GetAnswersByQuestionnaireIdAsync(int idQuestionnaire)
        {
            var query = @"
                SELECT a.*, q.question AS QuestionDescription,
                       e.name AS EstablishmentName, qt.description AS QuestionnaireName
                FROM answers a
                INNER JOIN establishment_questionnaires eq ON eq.id_questionnaire = a.id_questionnaire
                INNER JOIN questions q ON q.id = a.id_question
                INNER JOIN establishments e ON e.id = a.id_establishment
                INNER JOIN questionnaires qt ON qt.id = a.id_questionnaire
                WHERE eq.id_questionnaire = @IdQuestionnaire";

            return await _session.Connection.QueryAsync<AnswerWithQuestionDescriptionDto>(query, new { IdQuestionnaire = idQuestionnaire });
        }

        public async Task<IEnumerable<AnswerWithQuestionDescriptionDto>> GetAnswersByEstablishmentQuestionnaireAsync(int idEstablishment, int idQuestionnaire)
        {
            var query = @"
            SELECT a.*, q.question AS QuestionDescription,
                       e.name AS EstablishmentName, qt.description AS QuestionnaireName
                FROM answers a
                INNER JOIN establishment_questionnaires eq ON eq.id_establishment = a.id_establishment
                INNER JOIN questions q ON q.id = a.id_question
                INNER JOIN establishments e ON e.id = a.id_establishment
                INNER JOIN questionnaires qt ON qt.id = a.id_questionnaire
                WHERE eq.id_establishment = @IdEstablishment AND eq.id_questionnaire = @IdQuestionnaire";

            return await _session.Connection.QueryAsync<AnswerWithQuestionDescriptionDto>(query, new { IdEstablishment = idEstablishment, IdQuestionnaire = idQuestionnaire });
        }

        public async Task<IEnumerable<AnswerWithQuestionDescriptionDto>> GetAllAnswersAsync()
        {
            var query = @"
                SELECT a.*, q.question AS QuestionDescription,
                       e.name AS EstablishmentName, qt.description AS QuestionnaireName
                FROM answers a
                INNER JOIN questions q ON q.id = a.id_question
                INNER JOIN establishments e ON e.id = a.id_establishment
                INNER JOIN questionnaires qt ON qt.id = a.id_questionnaire";

            return await _session.Connection.QueryAsync<AnswerWithQuestionDescriptionDto>(query);
        }

        public async Task<IEnumerable<IGrouping<string, AnswerWithQuestionDescriptionDto>>> GetAnswersGroupedByUniqueCodeAsync()
        {
            var query = @"
               SELECT a.*, q.question AS QuestionDescription,
                       e.name AS EstablishmentName, qt.description AS QuestionnaireName
                FROM answers a
                INNER JOIN questions q ON q.id = a.id_question
                INNER JOIN establishments e ON e.id = a.id_establishment
                INNER JOIN questionnaires qt ON qt.id = a.id_questionnaire";

            var result = await _session.Connection.QueryAsync<AnswerWithQuestionDescriptionDto>(query);
            return result.GroupBy(a => a.UniqueCode);
        }
    }
}
