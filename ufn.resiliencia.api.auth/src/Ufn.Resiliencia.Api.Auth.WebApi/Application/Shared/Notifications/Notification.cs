using System.Diagnostics.CodeAnalysis;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Application.Shared.Notifications;

[ExcludeFromCodeCoverage]
public class Notification
{
    public string Key { get; }
    public string Message { get; }

    public Notification(string key, string message)
    {
        Key = key;
        Message = message;
    }
}