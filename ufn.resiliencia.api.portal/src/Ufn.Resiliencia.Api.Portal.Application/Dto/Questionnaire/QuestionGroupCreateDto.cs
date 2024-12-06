using Ufn.Resiliencia.Api.Portal.Application.Dto.Shared;

namespace Ufn.Resiliencia.Api.Portal.Application.Dto.Questionnaire;
public class QuestionGroupCreateDto : BaseDto
{
    public int IdQuestionnaire { get; set; }
    public string Description { get; set; }
    public int QuestionGroupOrder { get; set; }
}
