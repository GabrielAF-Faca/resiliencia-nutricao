﻿using System.Net;
using System.Text.Json;

using Microsoft.AspNetCore.Mvc.Filters;

using Serilog;

using Ufn.Resiliencia.Api.Portal.Domain.Shared.Notifications;

namespace Ufn.Resiliencia.Api.Portal.Api.Filters;

public class NotificationFilter : IAsyncResultFilter
{
    private readonly NotificationContext _notificationContext;

    public NotificationFilter(NotificationContext notificationContext)
    {
        _notificationContext = notificationContext;
    }

    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (_notificationContext.HasNotifications)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.HttpContext.Response.ContentType = "application/json";

            var notifications = JsonSerializer.Serialize(_notificationContext.Notifications);
            Log.Warning(notifications);
            await context.HttpContext.Response.WriteAsync(notifications);
        }

        if (!context.HttpContext.Response.HasStarted)
            await next();
    }
}