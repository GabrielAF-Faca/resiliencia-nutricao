using System.Data;
using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using MySqlConnector;

using Ufn.Resiliencia.Api.Portal.Infra.ConfigurationOptions;

namespace Ufn.Resiliencia.Api.Portal.Infra.Data.MySql;

[ExcludeFromCodeCoverage]
public sealed class MySqlDbSession : IDisposable
{
    private readonly IOptions<MySqlConnectionOptions> _configurationOptions;
    public IDbConnection Connection { get; }
    public IDbTransaction? Transaction { get; set; }

    public MySqlDbSession(IServiceProvider serviceProvider)
    {
        var config = serviceProvider.GetService<IOptions<MySqlConnectionOptions>>();
        if (config == null)
        {
            throw new InvalidOperationException("Postgre Configuration Options not found");
        }
        _configurationOptions = config;
        Connection = new MySqlConnection(_configurationOptions.Value.ConnectionString);
        Connection.Open();
    }

    public void Dispose() => Connection?.Dispose();
}
