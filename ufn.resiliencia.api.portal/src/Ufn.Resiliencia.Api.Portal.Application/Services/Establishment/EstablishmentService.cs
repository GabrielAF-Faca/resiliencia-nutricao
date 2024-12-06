using Mapster;

using Ufn.Resiliencia.Api.Portal.Application.Dto.Establishment;
using Ufn.Resiliencia.Api.Portal.Application.Services.Shared;
using Ufn.Resiliencia.Api.Portal.Domain.Shared.Notifications;
using Ufn.Resiliencia.Api.Portal.Infra.Data.MySql;

using EstablishmentDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.Establishment;

namespace Ufn.Resiliencia.Api.Portal.Application.Services.Establishment;
public class EstablishmentService : BaseService, IEstablishmentService
{
    private readonly IMySqlUnitOfWork _uow;

    public EstablishmentService(NotificationContext notificationContext, IMySqlUnitOfWork uow) : base(notificationContext)
    {
        _uow = uow;
    }

    public async Task<IEnumerable<EstablishmentResponseDto>> GetAllEstablishmentsAsync()
    {
        var result = await _uow.EstablishmentRepository.GetAll();

        var response = result.Adapt<IEnumerable<EstablishmentResponseDto>>();

        return response;
    }

    public async Task<IEnumerable<EstablishmentPublicResponseDto>> GetEstablishmentListAsync()
    {
        var result = await _uow.EstablishmentRepository.GetAll();

        var response = result.Adapt<IEnumerable<EstablishmentPublicResponseDto>>();

        return response;
    }

    public async Task<EstablishmentResponseDto?> GetEstablishmentByIdAsync(int id)
    {
        var result = await _uow.EstablishmentRepository.GetById(id);

        if (result == null)
        {
            return null;
        }

        var response = result.Adapt<EstablishmentResponseDto>();

        return response;
    }

    public async Task<int?> CreateEstablishmentAsync(EstablishmentCreateDto dto)
    {
        ValidateDto(dto, new EstablishmentCreateDtoValidator());

        if (NotificationContext.HasNotifications)
        {
            return null;
        }

        var model = dto.Adapt<EstablishmentDomain>();
        model.Active = true;

        var result = await _uow.EstablishmentRepository.Create(model);
        await _uow.CommitContextAsync();

        return result.Id;
    }

    public async Task UpdateEstablishmentAsync(EstablishmentUpdateDto dto)
    {
        ValidateDto(dto, new EstablishmentUpdateDtoValidator());

        if (NotificationContext.HasNotifications)
        {
            return;
        }

        var model = await _uow.EstablishmentRepository.GetById(dto.Id);
        if (model == null)
        {
            NotificationContext.AddNotification("NotFound", "Estabelecimento não encontrado");
            return;
        }

        dto.Adapt(model);

        _uow.EstablishmentRepository.Update(model);
        await _uow.CommitContextAsync();
    }

    public async Task DeleteEstablishmentAsync(int id)
    {
        var model = await _uow.EstablishmentRepository.GetById(id);
        if (model == null)
        {
            NotificationContext.AddNotification("NotFound", "Estabelecimento não encontrado");
            return;
        }

        var establishmentHasQuestionnaires = await _uow.EstablishmentRepository.EstablishmentHasQuestionnaires(id);

        if (establishmentHasQuestionnaires)
        {
            _uow.EstablishmentRepository.SoftDelete(model);
            await _uow.CommitContextAsync();
            return;
        }

        _uow.EstablishmentRepository.DeleteAt(model);
        await _uow.CommitContextAsync();
    }
}
