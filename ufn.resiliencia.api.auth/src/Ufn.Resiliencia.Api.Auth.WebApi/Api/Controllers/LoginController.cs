using System.Net;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Ufn.Resiliencia.Api.Auth.WebApi.Api.Controllers.Shared;
using Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.Login;
using Ufn.Resiliencia.Api.Auth.WebApi.Application.Services.Login;
using Ufn.Resiliencia.Api.Auth.WebApi.Application.Shared.Notifications;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Api.Controllers;

[ProducesResponseType(typeof(Notification), (int)HttpStatusCode.BadRequest)]
[ProducesResponseType(typeof(Notification), (int)HttpStatusCode.InternalServerError)]
[ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
[Route("api/login")]
[AllowAnonymous]
public class LoginController : BaseController
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService) 
    {
        _loginService = loginService;
    }

    /// <summary>
    /// Realiza o login de um usuário
    /// </summary>
    /// <param name="dto">Corpo da requisição</param>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpPost]
    [ProducesResponseType(typeof(LoginResponseDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> LoginAsync([FromBody] LoginDto dto)
    {
        var response = await _loginService.PerformLoginAsync(dto);
        return Ok(response);
    }
}
