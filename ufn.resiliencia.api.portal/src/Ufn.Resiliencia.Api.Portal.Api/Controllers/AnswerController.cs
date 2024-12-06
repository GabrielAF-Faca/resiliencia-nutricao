using System.Net;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Ufn.Resiliencia.Api.Portal.Api.Controllers.Shared;
using Ufn.Resiliencia.Api.Portal.Application.Dto.Answer;
using Ufn.Resiliencia.Api.Portal.Application.Services.Answer;

namespace Ufn.Resiliencia.Api.Portal.Api.Controllers
{
    [Route("api/answers")]
    public class AnswerController : BaseController
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        /// <summary>
        /// Salva as questões respondidas
        /// </summary>
        /// <param name="dto">Corpo da requisição</param>
        /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAnswers([FromBody] AnswerRequestCreateDto dto)
        {
            var response = await _answerService.CreateAnswersAsync(dto);
            return CreatedAtAction(nameof(CreateAnswers), response);
        }

        /// <summary>
        /// Atualiza as questões respondidas
        /// </summary>
        /// <param name="dto">Corpo da requisição</param>
        /// <returns>Retorna sucesso ou falha, conforme documentação</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> UpdateAnswers([FromBody] AnswerRequestUpdateDto dto)
        {
            await _answerService.UpdateAnswersAsync(dto);
            return NoContent();
        }

        /// <summary>
        /// Obtém as respostas por ID do questionário
        /// </summary>
        /// <param name="idQuestionnaire">ID do questionário</param>
        /// <returns>Lista de respostas</returns>
        [HttpGet("by-questionnaire/{idQuestionnaire}")]
        [ProducesResponseType(typeof(IEnumerable<AnswerResponseDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAnswersByQuestionnaire(int idQuestionnaire)
        {
            var answers = await _answerService.GetAnswersByQuestionnaireAsync(idQuestionnaire);
            return Ok(answers);
        }

        /// <summary>
        /// Obtém as respostas por ID do questionário e ID do estabelecimento
        /// </summary>
        /// <param name="idQuestionnaire">ID do questionário</param>
        /// <param name="idEstablishment">ID do estabelecimento</param>
        /// <returns>Lista de respostas</returns>
        [HttpGet("by-establishment-questionnaire/{idEstablishment}/{idQuestionnaire}")]
        [ProducesResponseType(typeof(IEnumerable<AnswerResponseDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAnswersByEstablishmentQuestionnaire(int idEstablishment, int idQuestionnaire)
        {
            var answers = await _answerService.GetAnswersByEstablishmentQuestionnaireAsync(idQuestionnaire, idEstablishment);
            return Ok(answers);
        }

        /// <summary>
        /// Obtém todas as respostas
        /// </summary>
        /// <returns>Lista de todas as respostas</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AnswerResponseDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAnswers()
        {
            var answers = await _answerService.GetAllAnswersAsync();
            return Ok(answers);
        }
    }
}
