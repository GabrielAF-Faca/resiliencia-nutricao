using System.Diagnostics.CodeAnalysis;
using System.Net;

using FluentValidation.Results;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Application.Shared.Notifications;

[ExcludeFromCodeCoverage]
public class NotificationContext
{
    private readonly List<Notification> _notifications;
    public IReadOnlyCollection<Notification> Notifications => _notifications;
    public bool HasNotifications => _notifications.Any();
    private int _statusCode;
    public int StatusCode => _statusCode;

    public NotificationContext()
    {
        _notifications = new List<Notification>();
    }

    public void AddNotification(string key, string message, int statusCode = (int)HttpStatusCode.BadRequest)
    {
        _statusCode = statusCode;
        _notifications.Add(new Notification(key, message));
    }

    public void AddNotification(Notification notification, int statusCode = (int)HttpStatusCode.BadRequest)
    {
        _statusCode = statusCode;
        _notifications.Add(notification);
    }

    public void AddNotifications(IReadOnlyCollection<Notification> notifications, int statusCode = (int)HttpStatusCode.BadRequest)
    {
        _statusCode = statusCode;
        _notifications.AddRange(notifications);
    }

    public void AddNotifications(IList<Notification> notifications, int statusCode = (int)HttpStatusCode.BadRequest)
    {
        _statusCode = statusCode;
        _notifications.AddRange(notifications);
    }

    public void AddNotifications(ICollection<Notification> notifications, int statusCode = (int)HttpStatusCode.BadRequest)
    {
        _statusCode = statusCode;
        _notifications.AddRange(notifications);
    }

    public void AddNotifications(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            AddNotification(error.ErrorCode, error.ErrorMessage);
        }
    }
}
