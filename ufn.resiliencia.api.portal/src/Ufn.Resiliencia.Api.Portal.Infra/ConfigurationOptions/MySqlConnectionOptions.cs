using System.Diagnostics.CodeAnalysis;

namespace Ufn.Resiliencia.Api.Portal.Infra.ConfigurationOptions;

[ExcludeFromCodeCoverage]

public sealed class MySqlConnectionOptions
{
    public string ConnectionString { get; set; } = string.Empty;
}
