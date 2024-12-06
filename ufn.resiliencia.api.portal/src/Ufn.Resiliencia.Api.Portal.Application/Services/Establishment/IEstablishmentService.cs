using Ufn.Resiliencia.Api.Portal.Application.Dto.Establishment;

namespace Ufn.Resiliencia.Api.Portal.Application.Services.Establishment;
public interface IEstablishmentService
{
    Task<IEnumerable<EstablishmentResponseDto>> GetAllEstablishmentsAsync();
    Task<IEnumerable<EstablishmentPublicResponseDto>> GetEstablishmentListAsync();
    Task<EstablishmentResponseDto?> GetEstablishmentByIdAsync(int id);
    Task<int?> CreateEstablishmentAsync(EstablishmentCreateDto dto);
    Task UpdateEstablishmentAsync(EstablishmentUpdateDto dto);
    Task DeleteEstablishmentAsync(int id);
}
