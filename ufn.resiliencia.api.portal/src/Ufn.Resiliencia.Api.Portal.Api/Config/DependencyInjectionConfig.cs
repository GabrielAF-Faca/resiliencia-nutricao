using Ufn.Resiliencia.Api.Portal.Application.Services.Answer;
using Ufn.Resiliencia.Api.Portal.Application.Services.Establishment;
using Ufn.Resiliencia.Api.Portal.Application.Services.Questionnaire;
using Ufn.Resiliencia.Api.Portal.Application.Services.RespondentGroup;
using Ufn.Resiliencia.Api.Portal.Domain.Shared.Notifications;
using Ufn.Resiliencia.Api.Portal.Infra.Data.MySql;

namespace Ufn.Resiliencia.Api.Portal.Api.Config;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjection(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        #region Databases
        services.AddScoped<IMySqlUnitOfWork, MySqlUnitOfWork>();
        #endregion

        #region Notification 
        services.AddScoped<NotificationContext>();
        #endregion

        #region Services
        services.AddScoped<IRespondentGroupService, RespondentGroupService>();
        services.AddScoped<IEstablishmentService, EstablishmentService>();
        services.AddScoped<IQuestionnaireService, QuestionnaireService>();
        services.AddScoped<IAnswerService, AnswerService>();
        #endregion
    }
}