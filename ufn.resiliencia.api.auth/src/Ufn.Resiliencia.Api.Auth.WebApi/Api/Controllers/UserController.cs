using System.Net;

using Microsoft.AspNetCore.Mvc;

using Ufn.Resiliencia.Api.Auth.WebApi.Api.Controllers.Shared;
using Ufn.Resiliencia.Api.Auth.WebApi.Api.Extensions;
using Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.User;
using Ufn.Resiliencia.Api.Auth.WebApi.Application.Services.User;
using Ufn.Resiliencia.Api.Auth.WebApi.Application.Shared.Notifications;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Api.Controllers;


[ProducesResponseType(typeof(Notification), (int)HttpStatusCode.BadRequest)]
[ProducesResponseType(typeof(Notification), (int)HttpStatusCode.InternalServerError)]
[ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
[Route("api/user")]
public class UserController : BaseController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Cadastra um novo usuário
    /// </summary>
    /// <param name="dto">Corpo da requisição</param>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
    {
        var response = await _userService.RegisterUser(dto);
        return CreatedAtAction(nameof(Register), response);
    }

    /// <summary>
    /// Atualiza um usuário
    /// </summary>
    /// <param name="dto">Corpo da requisição</param>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> Update([FromBody] UpdateUserDto dto)
    {
        await _userService.UpdateUser(dto);
        return NoContent();
    }

    /// <summary>
    /// Bloqueia um usuário
    /// </summary>
    /// <param name="dto">Corpo da requisição</param>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpPut]
    [Route("block")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> Block([FromBody] BlockAndUnblockUserDto dto)
    {
        dto.IsBlocked = true;
        await _userService.BlockAndUnblockUserAsync(dto);
        return NoContent();
    }

    /// <summary>
    /// Bloqueia um usuário
    /// </summary>
    /// <param name="dto">Corpo da requisição</param>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpPut]
    [Route("unblock")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> Unblock([FromBody] BlockAndUnblockUserDto dto)
    {
        dto.IsBlocked = false;
        await _userService.BlockAndUnblockUserAsync(dto);
        return NoContent();
    }

    /// <summary>
    /// Busca a lista dos usuários
    /// </summary>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UserResponseDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllEstablishments()
    {
        var id = this.GetUserIdClaim();
        var response = await _userService.GetAll(id);
        return Ok(response);
    }

    /// <summary>
    /// Busca um usuário
    /// </summary>
    /// <param name="id">Id do usuário</param>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(UserResponseDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetEstablishmentById([FromRoute] string id)
    {
        var response = await _userService.Get(id);
        return Ok(response);
    }
}
