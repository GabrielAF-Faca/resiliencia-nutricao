using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Ufn.Resiliencia.Api.Portal.Domain.Extensions;

[ExcludeFromCodeCoverage]
public static class DateTimeExtension
{
    private const string TimeZoneIdWindows = "E. South America Standard Time";
    private const string TimeZoneIdLinux = "America/Sao_Paulo";

    /// <summary>
    /// Busca DateTime.Now na time zone de Brasília.
    /// </summary>
    /// <param name="dateTime">Date time no formato Utc DateTime.UtcNow</param>
    /// <returns></returns>
    public static DateTime NowBrazilianTimeZone(this DateTime dateTime)
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
            ? TimeZoneInfo.ConvertTimeFromUtc(dateTime, TimeZoneInfo.FindSystemTimeZoneById(TimeZoneIdLinux))
            : TimeZoneInfo.ConvertTimeFromUtc(dateTime, TimeZoneInfo.FindSystemTimeZoneById(TimeZoneIdWindows));
    }
}