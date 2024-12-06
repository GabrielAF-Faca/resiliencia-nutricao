using Ufn.Resiliencia.Api.Portal.Domain.Entities.Shared;

namespace Ufn.Resiliencia.Api.Portal.Domain.Entities;
public class Questionnaire : BaseEntity
{
    public int IdRespondentGroup { get; set; }
    public string Description { get; set; }
    public bool Active { get; set; }
    public ICollection<QuestionGroup> QuestionGroups { get; set; }
}
