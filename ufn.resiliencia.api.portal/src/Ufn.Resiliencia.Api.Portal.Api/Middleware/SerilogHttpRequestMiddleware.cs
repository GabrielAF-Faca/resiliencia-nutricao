using System.Diagnostics.CodeAnalysis;
using System.Text;

using Serilog.Context;

using Ufn.Resiliencia.Api.Portal.Api.Util;

namespace Ufn.Resiliencia.Api.Portal.Api.Middleware;

[ExcludeFromCodeCoverage]
public class SerilogHttpRequestMiddleware
{
    private const string HttpRequestPropertyName = "HttpRequest";
    readonly RequestDelegate _next;

    public SerilogHttpRequestMiddleware(RequestDelegate next)
    {
        if (next == null)
        {
            throw new ArgumentNullException(nameof(next));
        }

        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        if (httpContext == null)
        {
            throw new ArgumentNullException(nameof(httpContext));
        }

        var httpRequestInfo = GetHttpRequestInfoAsync(httpContext);

        using (LogContext.PushProperty(HttpRequestPropertyName, httpRequestInfo, true))
        {
            await _next(httpContext);
        }
    }

    private HttpContextInfo? GetHttpRequestInfoAsync(HttpContext httpContext)
    {
        var httpRequest = httpContext?.Request;

        if (httpRequest == null)
        {
            return null;
        }

        string body = "";

        if (httpRequest.ContentLength.HasValue && httpRequest.ContentLength > 0)
        {
            httpRequest.EnableBuffering();

            using (var reader = new StreamReader(httpRequest.Body, Encoding.UTF8, false, 1024, true))
            {
                body = AsyncUtil.RunSync(() => reader.ReadToEndAsync());
            }

            httpRequest.Body.Position = 0;
        }

        return new HttpContextInfo()
        {
            ExternalConsumerId = GetConsumerId(httpContext),
            CpfCnpj = GetConsumerCpf(httpContext),
            Host = httpRequest.Host.ToString(),
            Path = httpRequest.Path,
            Scheme = httpRequest.Scheme,
            Method = httpRequest.Method,
            QueryString = httpRequest.Query.ToDictionary(x => x.Key, y => y.Value.ToString()),
            Headers = httpRequest.Headers
                        .Where(x =>
                            x.Key != "Cookie" &&
                            x.Key != "Authorization" &&
                            !x.Key.Contains("x-"))
                        .ToDictionary(x => x.Key, y => y.Value.ToString()),
            Cookies = httpRequest.Cookies.ToDictionary(x => x.Key, y => y.Value.ToString()),
            Body = body
        };
    }

    private string? GetConsumerId(HttpContext? context)
    {
        if (context == null || context.User == null) return null;

        var userClaims = context.User.Claims.ToList();
        var consumerId = userClaims?.FirstOrDefault(a => a.Type == "consumer_id");

        return consumerId?.Value;
    }

    private string? GetConsumerCpf(HttpContext? context)
    {
        if (context == null || context.User == null) return null;

        var userClaims = context.User.Claims.ToList();
        var consumerCpf = userClaims?.FirstOrDefault(a => a.Type == "cpf");
        return consumerCpf?.Value;
    }
}

[ExcludeFromCodeCoverage]
internal class HttpContextInfo
{
    public string? ExternalConsumerId { get; set; }
    public string? CpfCnpj { get; set; }
    public string Host { get; set; }
    public string Path { get; set; }
    public string Scheme { get; set; }
    public string Method { get; set; }
    public Dictionary<string, string> QueryString { get; set; }
    public Dictionary<string, string> Headers { get; set; }
    public Dictionary<string, string> Cookies { get; set; }
    public string Body { get; set; }
}