using System.Net;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Ufn.Resiliencia.Api.Portal.Api.Controllers.Shared;
using Ufn.Resiliencia.Api.Portal.Application.Dto.Questionnaire;
using Ufn.Resiliencia.Api.Portal.Application.Services.Questionnaire;

namespace Ufn.Resiliencia.Api.Portal.Api.Controllers;

[Route("api/questionnaires")]
[AllowAnonymous] //REMOVER
public class QuestionnaireController : BaseController
{
    private readonly IQuestionnaireService _questionnaireService;

    public QuestionnaireController(IQuestionnaireService questionnaireService)
    {
        _questionnaireService = questionnaireService;
    }

    /// <summary>
    /// Cria um novo questionário
    /// </summary>
    /// <param name="dto">Corpo da requisição</param>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpPost]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> CreateQuestionnaire([FromBody] QuestionnaireCreateDto dto)
    {
        var response = await _questionnaireService.CreateQuestionnaireAsync(dto);
        return CreatedAtAction(nameof(CreateQuestionnaire), response);
    }

    /// <summary>
    /// Atualiza um questionário
    /// </summary>
    /// <param name="dto">Corpo da requisição</param>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> UpdateQuestionnaire([FromBody] QuestionnaireUpdateDto dto)
    {
        await _questionnaireService.UpdateQuestionnaireAsync(dto);
        return NoContent();
    }

    /// <summary>
    /// Exclui um questionário
    /// </summary>
    /// <param name="id">Id do Questionário</param>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> DeleteQuestionnaire([FromRoute] int id)
    {
        await _questionnaireService.DeleteQuestionnaireAsync(id);
        return NoContent();
    }

    /// <summary>
    /// Busca a lista de questionários
    /// </summary>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<QuestionnaireResponseBasicDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllQuestionnaires()
    {
        var response = await _questionnaireService.GetAllQuestionnairesAsync();
        return Ok(response);
    }

    /// <summary>
    /// Busca um questionário
    /// </summary>
    /// <param name="id">Id do Questionário</param>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(QuestionnaireResponseBasicDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetQuestionnaire([FromRoute] int id)
    {
        var response = await _questionnaireService.GetQuestionnaireAsync(id);
        return Ok(response);
    }

    /// <summary>
    /// Cria um novo grupo de questões
    /// </summary>
    /// <param name="dto">Corpo da requisição</param>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpPost]
    [Route("question-group")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> CreateQuestionGroup([FromBody] QuestionGroupCreateDto dto)
    {
        var response = await _questionnaireService.CreateQuestionGroupAsync(dto);
        return CreatedAtAction(nameof(CreateQuestionGroup), response);
    }

    /// <summary>
    /// Atualiza um grupo de questões
    /// </summary>
    /// <param name="dto">Corpo da requisição</param>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpPut]
    [Route("question-group")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> UpdateQuestionGroup([FromBody] QuestionGroupUpdateDto dto)
    {
        await _questionnaireService.UpdateQuestionGroupAsync(dto);
        return NoContent();
    }

    /// <summary>
    /// Exclui um grupo de questões
    /// </summary>
    /// <param name="id">Id do Grupo de Questões</param>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpDelete]
    [Route("question-group/{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> DeleteQuestionGroup([FromRoute] int id)
    {
        await _questionnaireService.DeleteQuestionGroupAsync(id);
        return NoContent();
    }

    /// <summary>
    /// Cria uma nova questão
    /// </summary>
    /// <param name="dto">Corpo da requisição</param>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpPost]
    [Route("question")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> CreateQuestion([FromBody] QuestionCreateDto dto)
    {
        var response = await _questionnaireService.CreateQuestionAsync(dto);
        return CreatedAtAction(nameof(CreateQuestion), response);
    }

    /// <summary>
    /// Atualiza uma questão
    /// </summary>
    /// <param name="dto">Corpo da requisição</param>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpPut]
    [Route("question")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> UpdateQuestion([FromBody] QuestionUpdateDto dto)
    {
        await _questionnaireService.UpdateQuestionAsync(dto);
        return NoContent();
    }

    /// <summary>
    /// Exclui uma questão
    /// </summary>
    /// <param name="id">Id da Questão</param>
    /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
    [HttpDelete]
    [Route("question/{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> DeleteQuestion([FromRoute] int id)
    {
        await _questionnaireService.DeleteQuestionGroupAsync(id);
        return NoContent();
    }

    [HttpGet]
    [Route("question/")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetQuestion()
    {
        var response = await _questionnaireService.GetQuestions();
        return Ok(response);
    }
    [HttpGet]
    [Route("question-group/")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetQuestionGroup()
    {
        var response = await _questionnaireService.GetQuestionGroups();
        return Ok(response);
    }
}
