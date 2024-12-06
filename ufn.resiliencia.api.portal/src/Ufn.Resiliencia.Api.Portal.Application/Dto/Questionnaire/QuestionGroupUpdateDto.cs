using Ufn.Resiliencia.Api.Portal.Application.Dto.Shared;

namespace Ufn.Resiliencia.Api.Portal.Application.Dto.Questionnaire;
public class QuestionGroupUpdateDto : BaseDto
{
    public int Id { get; set; }
    public int IdQuestionnaire { get; set; }
    public string Description { get; set; }
    public int QuestionGroupOrder { get; set; }
}
