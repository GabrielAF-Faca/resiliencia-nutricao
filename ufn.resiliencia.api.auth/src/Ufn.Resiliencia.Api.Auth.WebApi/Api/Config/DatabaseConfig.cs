using Microsoft.EntityFrameworkCore;

using Ufn.Resiliencia.Api.Auth.WebApi.Infra.Data.MySql;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Api.Config;

public static class DatabaseConfig
{
    public static void AddDatabaseConfiguration(this IServiceCollection services,
        IConfiguration config)
    {
        var mySqlServerVersion = new MySqlServerVersion(new Version(8, 0, 32));
        services.AddDbContext<MySqlContext>(opt =>
            opt.UseMySql(config.GetValue<string>("ConnectionStrings:MySQLConnection"), mySqlServerVersion));
    }
}