using Ufn.Resiliencia.Api.Portal.Application.Dto.Shared;

namespace Ufn.Resiliencia.Api.Portal.Application.Dto.Questionnaire;
public class QuestionnaireUpdateDto : BaseDto
{
    public int Id { get; set; }
    public int IdRespondentGroup { get; set; }
    public string Description { get; set; }
    public IEnumerable<QuestionGroupDto> QuestionGroups { get; set; }
}
