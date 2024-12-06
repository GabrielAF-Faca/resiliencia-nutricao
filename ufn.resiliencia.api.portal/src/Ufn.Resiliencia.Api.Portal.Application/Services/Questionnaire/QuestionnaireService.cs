using Mapster;

using Ufn.Resiliencia.Api.Portal.Application.Dto.Questionnaire;
using Ufn.Resiliencia.Api.Portal.Application.Services.Shared;
using Ufn.Resiliencia.Api.Portal.Domain.Shared.Notifications;
using Ufn.Resiliencia.Api.Portal.Infra.Data.MySql;

using QuestionDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.Question;
using QuestionGroupDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.QuestionGroup;
using QuestionnaireDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.Questionnaire;

namespace Ufn.Resiliencia.Api.Portal.Application.Services.Questionnaire;
public class QuestionnaireService : BaseService, IQuestionnaireService
{

    private readonly IMySqlUnitOfWork _uow;

    public QuestionnaireService(NotificationContext notificationContext, IMySqlUnitOfWork uow) : base(notificationContext)
    {
        _uow = uow;
    }

    public async Task<int?> CreateQuestionnaireAsync(QuestionnaireCreateDto dto)
    {
        ValidateDto(dto, new QuestionnaireCreateDtoValidator());

        foreach (var questionGroup in dto.QuestionGroups)
        {
            ValidateDto(questionGroup, new QuestionGroupDtoValidator());
            foreach(var question in questionGroup.Questions)
            {
                ValidateDto(question, new QuestionDtoValidator());
            }
        }

        if (NotificationContext.HasNotifications)
        {
            return null;
        }

        var respondendGroup = await _uow.RespondentGroupRepository.GetById(dto.IdRespondentGroup);

        if (respondendGroup == null)
        {
            NotificationContext.AddNotification("NotFound", "Grupo de respondentes não encontrado");
            return null;
        }

        var questionnaire = dto.Adapt<QuestionnaireDomain>();
        questionnaire.Active = true;

        foreach (var questionGroup in questionnaire.QuestionGroups)
        {
            questionGroup.Active = true;

            foreach (var question in questionGroup.Questions)
            {
                question.Active = true;
            }
        }

        var questionnaireCreated = await _uow.QuestionnaireRepository.Create(questionnaire);
        
        await _uow.CommitContextAsync();

        return questionnaireCreated.Id;
    }



    public async Task UpdateQuestionnaireAsync(QuestionnaireUpdateDto dto)
    {
        ValidateDto(dto, new QuestionnaireUpdateDtoValidator());

        foreach (var questionGroup in dto.QuestionGroups)
        {
            ValidateDto(questionGroup, new QuestionGroupDtoValidator());
            foreach (var question in questionGroup.Questions)
            {
                ValidateDto(question, new QuestionDtoValidator());
            }
        }

        if (NotificationContext.HasNotifications)
        {
            return;
        }

        var model = await _uow.QuestionnaireRepository.GetCompleteById(dto.Id);
        if (model == null)
        {
            NotificationContext.AddNotification("NotFound", "Questionário não encontrado");
            return;
        }

        var respondendGroup = await _uow.RespondentGroupRepository.GetById(dto.IdRespondentGroup);

        if (respondendGroup == null)
        {
            NotificationContext.AddNotification("NotFound", "Grupo de respondentes não encontrado");
            return;
        }

        dto.Adapt(model);

        _uow.QuestionnaireRepository.Update(model);
        await _uow.CommitContextAsync();
    }

    public async Task<IEnumerable<QuestionnaireResponseBasicDto>> GetAllQuestionnairesAsync()
    {
        var result = await _uow.QuestionnaireRepository.GetAllBasic();

        var response = result.Adapt<IEnumerable<QuestionnaireResponseBasicDto>>();

        return response;
    }

    public async Task<IEnumerable<QuestionnaireResponseBasicDto>> GetAllQuestionnairesByEstablishmentAsync(int establishmentId)
    {
        var result = await _uow.QuestionnaireRepository.GetAllBasicByEstablishment(establishmentId);

        var response = result.Adapt<IEnumerable<QuestionnaireResponseBasicDto>>();

        return response;
    }

    public async Task<QuestionnaireResponseDto?> GetQuestionnaireAsync(int id)
    {
        var result = await _uow.QuestionnaireRepository.GetCompleteById(id);

        if (result == null)
        {
            return null;
        }
        var response = result.Adapt<QuestionnaireResponseDto>();
        return response;
    }

    public async Task DeleteQuestionnaireAsync(int id)
    {
        var model = await _uow.QuestionnaireRepository.GetById(id);
        if (model == null)
        {
            NotificationContext.AddNotification("NotFound", "Questionário não encontrado");
            return;
        }

        var questionnaireHasQuestionsGroup = await _uow.QuestionnaireRepository.QuestionnaireHasQuestionsGroup(id);

        if (questionnaireHasQuestionsGroup)
        {
            _uow.QuestionnaireRepository.SoftDelete(model);
            await _uow.CommitContextAsync();
            return;
        }

        _uow.QuestionnaireRepository.DeleteAt(model);
        await _uow.CommitContextAsync();
    }

    public async Task<int?> CreateQuestionGroupAsync(QuestionGroupCreateDto dto)
    {
        ValidateDto(dto, new QuestionGroupCreateDtoValidator());

        if (NotificationContext.HasNotifications)
        {
            return null;
        }

        var questionnaire = await _uow.QuestionnaireRepository.GetById(dto.IdQuestionnaire);

        if (questionnaire == null)
        {
            NotificationContext.AddNotification("NotFound", "Questionário não encontrado");
            return null;
        }

        var model = dto.Adapt<QuestionGroupDomain>();
        model.Active = true;

        var result = await _uow.QuestionGroupRepository.Create(model);
        await _uow.CommitContextAsync();

        return result.Id;
    }

    public async Task UpdateQuestionGroupAsync(QuestionGroupUpdateDto dto)
    {
        ValidateDto(dto, new QuestionGroupUpdateDtoValidator());
        if (NotificationContext.HasNotifications)
        {
            return;
        }

        var model = await _uow.QuestionGroupRepository.GetById(dto.Id);
        if (model == null)
        {
            NotificationContext.AddNotification("NotFound", "Grupo de questões não encontrado");
            return;
        }

        var questionnaire = await _uow.QuestionnaireRepository.GetById(dto.IdQuestionnaire);

        if (questionnaire == null)
        {
            NotificationContext.AddNotification("NotFound", "Questionário não encontrado");
            return;
        }

        dto.Adapt(model);

        _uow.QuestionGroupRepository.Update(model);
        await _uow.CommitContextAsync();
    }

    public async Task DeleteQuestionGroupAsync(int id)
    {
        var model = await _uow.QuestionGroupRepository.GetById(id);
        if (model == null)
        {
            NotificationContext.AddNotification("NotFound", "Grupo de questões não encontrado");
            return;
        }

        var questionGroupHasQuestions = await _uow.QuestionGroupRepository.QuestionGroupHasQuestions(id);

        if (questionGroupHasQuestions)
        {
            _uow.QuestionGroupRepository.SoftDelete(model);
            await _uow.CommitContextAsync();
            return;
        }

        _uow.QuestionGroupRepository.DeleteAt(model);
        await _uow.CommitContextAsync();
    }

    public async Task<int?> CreateQuestionAsync(QuestionCreateDto dto)
    {
        ValidateDto(dto, new QuestionCreateDtoValidator());

        if (NotificationContext.HasNotifications)
        {
            return null;
        }

        //var questionGroup = await _uow.QuestionGroupRepository.GetById(dto.IdQuestionGroup);

        //if (questionGroup == null)
        //{
        //    NotificationContext.AddNotification("NotFound", "Grupo de questões não encontrado");
        //    return null;
        //}

        var model = dto.Adapt<QuestionDomain>();
        model.Active = true;

        var result = await _uow.QuestionRepository.Create(model);
        await _uow.CommitContextAsync();

        return result.Id;
    }

    public async Task UpdateQuestionAsync(QuestionUpdateDto dto)
    {
        ValidateDto(dto, new QuestionUpdateDtoValidator());
        if (NotificationContext.HasNotifications)
        {
            return;
        }

        var model = await _uow.QuestionRepository.GetById(dto.Id);
        if (model == null)
        {
            NotificationContext.AddNotification("NotFound", "Questão não encontrada");
            return;
        }

        var questionGroup = await _uow.QuestionGroupRepository.GetById(dto.IdQuestionGroup);

        if (questionGroup == null)
        {
            NotificationContext.AddNotification("NotFound", "Grupo de questões não encontrado");
            return;
        }

        dto.Adapt(model);

        _uow.QuestionRepository.Update(model);
        await _uow.CommitContextAsync();
    }

    public async Task DeleteQuestionAsync(int id)
    {
        var model = await _uow.QuestionRepository.GetById(id);
        if (model == null)
        {
            NotificationContext.AddNotification("NotFound", "Questão não encontrada");
            return;
        }

        var questionHasAnswers = await _uow.QuestionRepository.QuestionHasAnswers(id);

        if (questionHasAnswers)
        {
            _uow.QuestionRepository.SoftDelete(model);
            await _uow.CommitContextAsync();
            return;
        }

        _uow.QuestionRepository.DeleteAt(model);
        await _uow.CommitContextAsync();
    }

    public async Task<IEnumerable<QuestionDto>> GetQuestions()
    {
        var result = await _uow.QuestionRepository.GetAll();

        var response = result.Adapt<IEnumerable<QuestionDto>>();

        return response;
    }

    public async Task<IEnumerable<QuestionGroupDto>> GetQuestionGroups()
    {
        var result = await _uow.QuestionGroupRepository.GetAll();

        var response = result.Adapt<IEnumerable<QuestionGroupDto>>();

        return response;
    }
}
