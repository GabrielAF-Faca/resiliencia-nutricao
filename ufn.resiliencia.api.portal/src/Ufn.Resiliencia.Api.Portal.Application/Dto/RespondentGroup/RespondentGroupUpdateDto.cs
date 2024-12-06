using Ufn.Resiliencia.Api.Portal.Application.Dto.Shared;

namespace Ufn.Resiliencia.Api.Portal.Application.Dto.RespondentGroup;
public class RespondentGroupUpdateDto : BaseDto
{
    public int Id { get; set; }
    public string Description { get; set; }

    public RespondentGroupUpdateDto()
    {
        Validate(this, new RespondentGroupUpdateDtoValidator());
    }
}
