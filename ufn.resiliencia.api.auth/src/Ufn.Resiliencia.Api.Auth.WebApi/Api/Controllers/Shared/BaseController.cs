using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;

using Ufn.Resiliencia.Api.Auth.WebApi.Application.Shared.Notifications;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Api.Controllers.Shared;

[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public abstract class BaseController : ControllerBase
{
}