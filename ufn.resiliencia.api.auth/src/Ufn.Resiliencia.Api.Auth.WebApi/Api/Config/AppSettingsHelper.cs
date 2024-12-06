namespace Ufn.Resiliencia.Api.Auth.WebApi.Api.Config;

public static class AppSettingsHelper
{
    private static IConfiguration _configuration;

    public static void AppSettingsConfigure(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public static T GetValue<T>(string key)
    {
        return _configuration.GetValue<T>(key);
    }
}

