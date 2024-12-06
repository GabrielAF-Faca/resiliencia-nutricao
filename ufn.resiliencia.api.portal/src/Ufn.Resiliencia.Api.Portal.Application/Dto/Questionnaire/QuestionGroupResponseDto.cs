namespace Ufn.Resiliencia.Api.Portal.Application.Dto.Questionnaire;
public class QuestionGroupResponseDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int QuestionGroupOrder { get; set; }
    public bool Active { get; set; }
    public IEnumerable<QuestionResponseDto> Questions { get; set; }
}
