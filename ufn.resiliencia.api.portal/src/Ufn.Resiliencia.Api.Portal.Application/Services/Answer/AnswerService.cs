using Mapster;

using Microsoft.EntityFrameworkCore;

using Ufn.Resiliencia.Api.Portal.Application.Dto.Answer;
using Ufn.Resiliencia.Api.Portal.Application.Services.Shared;
using Ufn.Resiliencia.Api.Portal.Domain.Shared.Notifications;
using Ufn.Resiliencia.Api.Portal.Infra.Data.MySql;

using AnswerDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.Answer;

namespace Ufn.Resiliencia.Api.Portal.Application.Services.Answer
{
    public class AnswerService : BaseService, IAnswerService
    {
        private readonly IMySqlUnitOfWork _uow;

        public AnswerService(NotificationContext notificationContext, IMySqlUnitOfWork uow) : base(notificationContext)
        {
            _uow = uow;
        }

        public async Task<string?> CreateAnswersAsync(AnswerRequestCreateDto dto)
        {
            ValidateDto(dto, new AnswerRequestCreateDtoValidator());

            foreach (var answer in dto.Answers)
            {
                ValidateDto(answer, new AnswerCreateDtoValidator());
            }

            if (NotificationContext.HasNotifications)
            {
                return null;
            }

            var establishment = await _uow.EstablishmentRepository.GetById(dto.IdEstablishment);

            if (establishment == null)
            {
                NotificationContext.AddNotification("NotFound", "Estabelecimento não encontrado");
                return null;
            }

            var uniqueCode = dto.UniqueCode ?? Guid.NewGuid().ToString();

            var models = dto.Answers.Adapt<ICollection<AnswerDomain>>();

            foreach (var model in models)
            {
                model.IdEstablishment = dto.IdEstablishment;
                model.IdQuestionnaire = dto.IdQuestionnaire;
                model.UniqueCode = uniqueCode;
            }

            await _uow.AnswerRepository.CreateMany(models);
            await _uow.EstablishmentQuestionnaireRepository.Create(new Domain.Entities.EstablishmentQuestionnaire
            {
                IdEstablishment = dto.IdEstablishment,
                IdQuestionnaire = dto.IdQuestionnaire
            });
            await _uow.CommitContextAsync();

            return uniqueCode;
        }

        public async Task UpdateAnswersAsync(AnswerRequestUpdateDto dto)
        {
            ValidateDto(dto, new AnswerRequestUpdateDtoValidator());

            foreach (var answer in dto.Answers)
            {
                ValidateDto(answer, new AnswerUpdateDtoValidator());
            }

            if (NotificationContext.HasNotifications)
            {
                return;
            }

            foreach (var answer in dto.Answers)
            {
                var model = await _uow.AnswerRepository.GetById(answer.Id);
                if (model == null)
                {
                    NotificationContext.AddNotification("NotFound", "Resposta não encontrada");
                    return;
                }

                answer.Adapt(model);
            }

            var models = dto.Answers.Adapt<ICollection<AnswerDomain>>();

            _uow.AnswerRepository.UpdateMany(models);

            await _uow.CommitContextAsync();
        }

        public async Task<IEnumerable<AnswerResponseDto>> GetAnswersByQuestionnaireAsync(int idQuestionnaire)
        {
            var answers = await _uow.AnswerRepository.GetAnswersByQuestionnaireIdAsync(idQuestionnaire);

            var answerDtos = answers.Adapt<ICollection<AnswerResponseDto>>();// Adicione outros campos conforme necessário

            return answerDtos;
        }
        public async Task<IEnumerable<AnswerResponseDto>> GetAnswersByEstablishmentQuestionnaireAsync(int idQuestionnaire,int IdEstablishment)
        {
            var answers = await _uow.AnswerRepository.GetAnswersByEstablishmentQuestionnaireAsync(IdEstablishment, idQuestionnaire);

            var answerDtos = answers.Adapt<ICollection<AnswerResponseDto>>();// Adicione outros campos conforme necessário


            return answerDtos;
        }

        // Novo método para buscar todas as respostas
        public async Task<IEnumerable<AnswerResponseDto>> GetAllAnswersAsync()
        {
            var answers = await _uow.AnswerRepository.GetAllAnswersAsync();

            var answerDtos = answers.Adapt<ICollection<AnswerResponseDto>>();// Adicione outros campos conforme necessário


            return answerDtos;
        }


    }
}
