using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

using Ufn.Resiliencia.Api.Auth.WebApi.Api.Controllers.Shared;
using Ufn.Resiliencia.Api.Auth.WebApi.Api.Extensions;
using Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.Password;
using Ufn.Resiliencia.Api.Auth.WebApi.Application.Services.Password;
using Ufn.Resiliencia.Api.Auth.WebApi.Application.Shared.Notifications;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Api.Controllers;

[ProducesResponseType(typeof(Notification), (int)HttpStatusCode.BadRequest)]
[ProducesResponseType(typeof(Notification), (int)HttpStatusCode.InternalServerError)]
[ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
[Route("api/password")]
public class PasswordController : BaseController
{
    private readonly IPasswordService _passwordService;
    public PasswordController(IPasswordService passwordService)
    {
        _passwordService = passwordService;
    }

    /// <summary>
    /// Altera a senha de um usuário
    /// </summary>
    /// <param name="dto">Corpo da requisição</param>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpPut]
    [Route("change")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangePasswordDto dto)
    {
        dto.UserId = this.GetUserIdClaim();
        await _passwordService.ChangePasswordAsync(dto);
        return NoContent();
    }
}
