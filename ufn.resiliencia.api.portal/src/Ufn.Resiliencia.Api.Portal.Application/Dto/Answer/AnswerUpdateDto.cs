using Ufn.Resiliencia.Api.Portal.Application.Dto.Shared;

namespace Ufn.Resiliencia.Api.Portal.Application.Dto.Answer;
public class AnswerUpdateDto : BaseDto
{
    public int Id { get; set; }
    public int IdQuestion { get; set; }
    public bool QuestionOneAnswered { get; set; }
    public bool QuestionTwoAnswered { get; set; }
    public bool QuestionThreeAnswered { get; set; }
    public bool AdditionalQuestionAnswered { get; set; }
}
