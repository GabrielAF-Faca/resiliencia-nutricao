using System.Net;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Ufn.Resiliencia.Api.Portal.Api.Controllers.Shared;
using Ufn.Resiliencia.Api.Portal.Application.Dto.RespondentGroup;
using Ufn.Resiliencia.Api.Portal.Application.Services.RespondentGroup;

namespace Ufn.Resiliencia.Api.Portal.Api.Controllers;

[Route("api/groups")]
public class RespondentGroupController : BaseController
{
    private readonly IRespondentGroupService _respondentGroupService;

    public RespondentGroupController(IRespondentGroupService respondentGroupService)
    {
        _respondentGroupService = respondentGroupService;
    }

    /// <summary>
    /// Cria um novo grupo de respondentes
    /// </summary>
    /// <param name="dto">Corpo da requisição</param>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpPost]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> CreateGroup([FromBody] RespondentGroupCreateDto dto)
    {
        var response = await _respondentGroupService.CreateAsync(dto);
        return CreatedAtAction(nameof(CreateGroup), response);
    }

    /// <summary>
    /// Atualiza um grupo de respondentes
    /// </summary>
    /// <param name="dto">Corpo da requisição</param>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> UpdateGroup([FromBody] RespondentGroupUpdateDto dto)
    {
        await _respondentGroupService.UpdateAsync(dto);
        return NoContent();
    }

    /// <summary>
    /// Exclui um grupo de respondentes
    /// </summary>
    /// <param name="id">Id do Grupo</param>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> DeleteGroup([FromRoute] int id)
    {
        await _respondentGroupService.DeleteAsync(id);
        return NoContent();
    }

    /// <summary>
    /// Busca a lista dos grupos de respondentes
    /// </summary>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<RespondentGroupResponseDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll()
    {
        var response = await _respondentGroupService.GetAllAsync();
        return Ok(response);
    }

    /// <summary>
    /// Busca um grupo de respondentes
    /// </summary>
    /// <param name="id">Id do Grupo</param>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(RespondentGroupResponseDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var response = await _respondentGroupService.GetByIdAsync(id);
        return Ok(response);
    }
}
