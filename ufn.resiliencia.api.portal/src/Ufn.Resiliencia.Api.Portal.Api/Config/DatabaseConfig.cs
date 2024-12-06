using Microsoft.EntityFrameworkCore;

using Ufn.Resiliencia.Api.Portal.Infra.ConfigurationOptions;
using Ufn.Resiliencia.Api.Portal.Infra.Data.MySql;

namespace Ufn.Resiliencia.Api.Portal.Api.Config;

public static class DatabaseConfig
{
    public static void AddDatabaseConfiguration(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddScoped<MySqlDbSession>();

        services
            .AddOptions<MySqlConnectionOptions>()
            .Configure(c => c.ConnectionString = config.GetConnectionString("MySQLConnection") ?? "");

        var mySqlServerVersion = new MySqlServerVersion(new Version(8, 0, 32));
        services.AddDbContext<MySqlContext>(opt =>
            opt.UseMySql(config.GetValue<string>("ConnectionStrings:MySQLConnection"), mySqlServerVersion));
    }
}