using Ufn.Resiliencia.Api.Portal.Application.Dto.Questionnaire;

namespace Ufn.Resiliencia.Api.Portal.Application.Services.Questionnaire;
public interface IQuestionnaireService
{
    Task<int?> CreateQuestionnaireAsync(QuestionnaireCreateDto dto);
    Task UpdateQuestionnaireAsync(QuestionnaireUpdateDto dto);
    Task<IEnumerable<QuestionnaireResponseBasicDto>> GetAllQuestionnairesAsync();
    Task<IEnumerable<QuestionnaireResponseBasicDto>> GetAllQuestionnairesByEstablishmentAsync(int establishmentId);
    Task<QuestionnaireResponseDto?> GetQuestionnaireAsync(int id);
    Task DeleteQuestionnaireAsync(int id);

    Task<int?> CreateQuestionGroupAsync(QuestionGroupCreateDto dto);
    Task UpdateQuestionGroupAsync(QuestionGroupUpdateDto dto);
    Task DeleteQuestionGroupAsync(int id);

    Task<int?> CreateQuestionAsync(QuestionCreateDto dto);
    Task UpdateQuestionAsync(QuestionUpdateDto dto);
    Task DeleteQuestionAsync(int id);

    Task<IEnumerable<QuestionDto>> GetQuestions();

    Task<IEnumerable<QuestionGroupDto>> GetQuestionGroups();
}
