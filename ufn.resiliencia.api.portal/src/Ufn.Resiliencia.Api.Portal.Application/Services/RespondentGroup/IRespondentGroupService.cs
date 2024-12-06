using Ufn.Resiliencia.Api.Portal.Application.Dto.RespondentGroup;

namespace Ufn.Resiliencia.Api.Portal.Application.Services.RespondentGroup;
public interface IRespondentGroupService
{
    Task<int?> CreateAsync(RespondentGroupCreateDto dto);
    Task UpdateAsync(RespondentGroupUpdateDto dto);
    Task DeleteAsync(int id);
    Task<IEnumerable<RespondentGroupResponseDto>> GetAllAsync();
    Task<RespondentGroupResponseDto?> GetByIdAsync(int id);
}
