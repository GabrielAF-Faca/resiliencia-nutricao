using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Reflection;
using System.Text.Json;

using Serilog;

using Ufn.Resiliencia.Api.Auth.WebApi.Application.Shared.Notifications;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Api.Middleware;

[ExcludeFromCodeCoverage]
public class GlobalExceptionHandlerMiddleware : IMiddleware
{

    public GlobalExceptionHandlerMiddleware()
    {

    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (AggregateException ex)
        {
            await HandleExceptionAsync(context, ex.InnerExceptions.First());
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        Log.Error(exception, $"Error on {Assembly.GetExecutingAssembly().GetName().Name}");

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        var options = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        return context.Response.WriteAsync(JsonSerializer.Serialize(new Notification("Internal server error", "Houve um erro ao processar sua requisição"), options));
    }
}