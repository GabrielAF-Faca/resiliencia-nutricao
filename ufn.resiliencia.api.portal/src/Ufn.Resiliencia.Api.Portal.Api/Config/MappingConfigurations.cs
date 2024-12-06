using System.Reflection;

using Mapster;

using Ufn.Resiliencia.Api.Portal.Application.Dto.Questionnaire;

using QuestionnaireDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.Questionnaire;

namespace Ufn.Resiliencia.Api.Portal.Api.Config;

public static class MappingConfigurations
{
    public static void RegisterMaps(this IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
    }
}
