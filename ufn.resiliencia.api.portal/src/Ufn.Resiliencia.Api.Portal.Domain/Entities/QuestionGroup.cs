using Ufn.Resiliencia.Api.Portal.Domain.Entities.Shared;

namespace Ufn.Resiliencia.Api.Portal.Domain.Entities;
public class QuestionGroup : BaseEntity
{
    public int IdQuestionnaire { get; set; }
    public string Description { get; set; }
    public int QuestionGroupOrder { get; set; }
    public bool Active { get; set; }
    public Questionnaire Questionnaire { get; set; }
    public ICollection<Question> Questions { get; set; }
}
