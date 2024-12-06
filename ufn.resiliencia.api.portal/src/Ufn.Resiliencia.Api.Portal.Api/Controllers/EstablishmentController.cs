using System.Net;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Ufn.Resiliencia.Api.Portal.Api.Controllers.Shared;
using Ufn.Resiliencia.Api.Portal.Application.Dto.Establishment;
using Ufn.Resiliencia.Api.Portal.Application.Services.Establishment;

namespace Ufn.Resiliencia.Api.Portal.Api.Controllers;

[Route("api/establishments")]
public class EstablishmentController : BaseController
{
    private readonly IEstablishmentService _establishmentService;

    public EstablishmentController(IEstablishmentService establishmentService)
    {
        _establishmentService = establishmentService;
    }

    /// <summary>
    /// Cria um novo estabelecimento
    /// </summary>
    /// <param name="dto">Corpo da requisição</param>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpPost]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> CreateEstablishment([FromBody] EstablishmentCreateDto dto)
    {
        var response = await _establishmentService.CreateEstablishmentAsync(dto);
        return CreatedAtAction(nameof(CreateEstablishment), response);
    }

    /// <summary>
    /// Atualiza um estabelecimento
    /// </summary>
    /// <param name="dto">Corpo da requisição</param>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> UpdateEstablishment([FromBody] EstablishmentUpdateDto dto)
    {
        await _establishmentService.UpdateEstablishmentAsync(dto);
        return NoContent();
    }

    /// <summary>
    /// Exclui um estabelecimento
    /// </summary>
    /// <param name="id">Id do Estabelecimento</param>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> DeleteEstablishment([FromRoute] int id)
    {
        await _establishmentService.DeleteEstablishmentAsync(id);
        return NoContent();
    }

    /// <summary>
    /// Busca a lista dos estabelecimentos
    /// </summary>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<EstablishmentResponseDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllEstablishments()
    {
        var response = await _establishmentService.GetAllEstablishmentsAsync();
        return Ok(response);
    }

    /// <summary>
    /// Busca a lista dos estabelecimentos de forma pública
    /// </summary>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpGet]
    [Route("list")]
    [ProducesResponseType(typeof(IEnumerable<EstablishmentPublicResponseDto>), (int)HttpStatusCode.OK)]
    [AllowAnonymous]
    public async Task<IActionResult> GetEstablishmentList()
    {
        var response = await _establishmentService.GetEstablishmentListAsync();
        return Ok(response);
    }

    /// <summary>
    /// Busca um estabelecimento
    /// </summary>
    /// <param name="id">Id do Estabelecimento</param>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(EstablishmentResponseDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetEstablishmentById([FromRoute] int id)
    {
        var response = await _establishmentService.GetEstablishmentByIdAsync(id);
        return Ok(response);
    }
}
