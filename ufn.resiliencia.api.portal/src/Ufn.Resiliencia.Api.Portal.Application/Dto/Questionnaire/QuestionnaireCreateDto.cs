using Ufn.Resiliencia.Api.Portal.Application.Dto.Shared;

namespace Ufn.Resiliencia.Api.Portal.Application.Dto.Questionnaire;
public class QuestionnaireCreateDto : BaseDto
{
    public int IdRespondentGroup { get; set; }
    public string Description { get; set; }
    public IEnumerable<QuestionGroupDto> QuestionGroups { get; set; }
}
