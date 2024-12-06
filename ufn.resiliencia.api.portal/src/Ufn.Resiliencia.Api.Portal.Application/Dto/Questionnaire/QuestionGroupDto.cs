using Ufn.Resiliencia.Api.Portal.Application.Dto.Shared;

namespace Ufn.Resiliencia.Api.Portal.Application.Dto.Questionnaire;
public class QuestionGroupDto : BaseDto
{
    public int? Id { get; set; }
    public string Description { get; set; }
    public int QuestionGroupOrder { get; set; }
    public IEnumerable<QuestionDto> Questions { get; set; }
}
