namespace Ufn.Resiliencia.Api.Portal.Application.Dto.Questionnaire;
public class QuestionnaireResponseBasicDto
{
    public int Id { get; set; }
    public int IdRespondentGroup { get; set; }
    public string Description { get; set; }
    public bool Active { get; set; }
}
