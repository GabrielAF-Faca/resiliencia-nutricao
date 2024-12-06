using System.Net;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Ufn.Resiliencia.Api.Portal.Domain.Shared.Notifications;

namespace Ufn.Resiliencia.Api.Portal.Api.Controllers.Shared;

[ApiController]
[ProducesResponseType(typeof(Notification), (int)HttpStatusCode.BadRequest)]
[ProducesResponseType(typeof(Notification), (int)HttpStatusCode.InternalServerError)]
[ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
[AllowAnonymous]
public abstract class BaseController : ControllerBase
{
}