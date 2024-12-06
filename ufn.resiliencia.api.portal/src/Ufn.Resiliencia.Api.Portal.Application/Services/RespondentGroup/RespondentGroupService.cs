using Mapster;

using Ufn.Resiliencia.Api.Portal.Application.Dto.RespondentGroup;
using Ufn.Resiliencia.Api.Portal.Application.Services.Shared;
using Ufn.Resiliencia.Api.Portal.Domain.Shared.Notifications;
using Ufn.Resiliencia.Api.Portal.Infra.Data.MySql;

using RespondentGroupDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.RespondentGroup;

namespace Ufn.Resiliencia.Api.Portal.Application.Services.RespondentGroup;
public class RespondentGroupService : BaseService, IRespondentGroupService
{
    private readonly IMySqlUnitOfWork _uow;

    public RespondentGroupService(NotificationContext notificationContext, IMySqlUnitOfWork uow) : base(notificationContext)
    {
        _uow = uow;
    }
    public async Task<IEnumerable<RespondentGroupResponseDto>> GetAllAsync()
    {
        var result = await _uow.RespondentGroupRepository.GetAll();

        var response = result.Adapt<IEnumerable<RespondentGroupResponseDto>>();

        return response;
    }

    public async Task<RespondentGroupResponseDto?> GetByIdAsync(int id)
    {
        var result = await _uow.RespondentGroupRepository.GetById(id);

        if (result == null)
        {
            return null;
        }

        var response = result.Adapt<RespondentGroupResponseDto>();

        return response;
    }

    public async Task<int?> CreateAsync(RespondentGroupCreateDto dto)
    {
        ValidateDto(dto, new RespondentGroupCreateDtoValidator());

        if (NotificationContext.HasNotifications)
        {
            return null;
        }

        var model = dto.Adapt<RespondentGroupDomain>();
        model.Active = true;

        var result = await _uow.RespondentGroupRepository.Create(model);
        await _uow.CommitContextAsync();

        return result.Id;
    }

    public async Task UpdateAsync(RespondentGroupUpdateDto dto)
    {
        ValidateDto(dto, new RespondentGroupUpdateDtoValidator());
        if (NotificationContext.HasNotifications)
        {
            return;
        }

        var model = await _uow.RespondentGroupRepository.GetById(dto.Id);
        if (model == null) 
        {
            NotificationContext.AddNotification("NotFound", "Grupo não encontrado");
            return;
        }

        dto.Adapt(model);

        _uow.RespondentGroupRepository.Update(model);
        await _uow.CommitContextAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var model = await _uow.RespondentGroupRepository.GetById(id);
        if (model == null)
        {
            NotificationContext.AddNotification("NotFound", "Grupo não encontrado");
            return;
        }

        var groupHasQuestionnaires = await _uow.RespondentGroupRepository.RespondentGroupHasQuestionnaires(id);

        if (groupHasQuestionnaires)
        {
            _uow.RespondentGroupRepository.SoftDelete(model);
            await _uow.CommitContextAsync();
            return;
        }

        _uow.RespondentGroupRepository.DeleteAt(model);
        await _uow.CommitContextAsync();
    }
}
