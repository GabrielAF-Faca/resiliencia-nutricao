using Ufn.Resiliencia.Api.Portal.Application.Dto.Answer;

namespace Ufn.Resiliencia.Api.Portal.Application.Services.Answer;
public interface IAnswerService
{
    Task<string?> CreateAnswersAsync(AnswerRequestCreateDto dto);
    Task UpdateAnswersAsync(AnswerRequestUpdateDto dto);
    Task<IEnumerable<AnswerResponseDto>> GetAnswersByQuestionnaireAsync(int idQuestionnaire);
    Task<IEnumerable<AnswerResponseDto>> GetAllAnswersAsync();
    Task<IEnumerable<AnswerResponseDto>> GetAnswersByEstablishmentQuestionnaireAsync(int idEstablishment, int idQuestionnaire);
}
