using Ufn.Resiliencia.Api.Portal.Application.Dto.Shared;

namespace Ufn.Resiliencia.Api.Portal.Application.Dto.Answer;
public class AnswerCreateDto : BaseDto
{
    public int IdQuestion { get; set; }

    public bool QuestionOneAnswered { get; set; }
    public bool QuestionTwoAnswered { get; set; }
    public bool? QuestionThreeAnswered { get; set; }
    public string? AdditionalQuestionAnswered { get; set; }
}
