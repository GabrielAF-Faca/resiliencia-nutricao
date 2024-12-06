using Ufn.Resiliencia.Api.Portal.Domain.Entities.Shared;

namespace Ufn.Resiliencia.Api.Portal.Domain.Entities;
public class Answer : BaseEntity
{
    public int IdEstablishment { get; set; }
    public int IdQuestion { get; set; }
    public int IdQuestionnaire { get; set; }
    public string UniqueCode { get; set; }
    public bool QuestionOneAnswered { get; set; }
    public bool QuestionTwoAnswered { get; set; }
    public bool QuestionThreeAnswered { get; set; }
    public bool AdditionalQuestionAnswered { get; set; }
}
