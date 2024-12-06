using Ufn.Resiliencia.Api.Portal.Application.Dto.Shared;

namespace Ufn.Resiliencia.Api.Portal.Application.Dto.Answer;
public class AnswerRequestUpdateDto : BaseDto
{
    public int IdEstablishment { get; set; }
    public int IdQuestionnaire { get; set; }
    public string? UniqueCode { get; set; }
    public IEnumerable<AnswerUpdateDto> Answers { get; set; }
}
