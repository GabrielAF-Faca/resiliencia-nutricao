using System.Reflection;

using Mapster;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Api.Config;

public static class MappingConfigurations
{
    public static void RegisterMaps(this IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
    }
}
