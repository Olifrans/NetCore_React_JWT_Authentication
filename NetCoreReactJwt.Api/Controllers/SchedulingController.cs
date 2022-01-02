using Microsoft.AspNetCore.Mvc;
using NetCoreReactJwt.BusinessManager.Interfaces;
using NetCoreReactJwt.Domain.Entities;


namespace NetCoreReactJwt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulingController : ControllerBase
    {
        private readonly ISchedulingBusinessManager _scheduling;
        public SchedulingController(ISchedulingBusinessManager schedule)
        {
            _scheduling = schedule;
        }


        /// <summary>
        /// Retorna todos os schedule cadastrado na base.
        /// </summary>
        /// <remarks>Este método retorna todos os schedule cadastrados na base de dados</remarks>
        [HttpGet]
        [ProducesResponseType(typeof(Scheduling), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSchedules()
        {
            return Ok(await _scheduling.GetScheduleAsync());
        }



        /// <summary>
        /// Retorna apenas um schedule consultado pelo id.
        /// </summary>
        /// <param name="id" example="123"> Id do cliente</param>
        /// <remarks>Este método retorna apenas um schedule da base de dados, consultado pelo id</remarks>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Scheduling), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSchedulesId(int id)
        {
            return Ok(await _scheduling.GetSchedulesIdAsync(id));
        }



        /// <summary>
        /// Cadastra um novo cliente.
        /// </summary>
        /// <param name="scheduling"></param>
        /// <returns></returns>
        /// <remarks>Este método cadastra um novo cliente na base de dados</remarks>
        [ProducesResponseType(typeof(Scheduling), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> PostSchedules(Scheduling scheduling)
        {
            Scheduling schedulingInserido;
            schedulingInserido = await _scheduling.InsertSchedulesAsync(scheduling);
            return CreatedAtAction(nameof(GetSchedulesId), new { id = schedulingInserido.Id }, schedulingInserido); //Status 
        }


        /// <summary>
        /// Altera um cliente cadastrado.
        /// </summary>
        /// <param name="scheduling"></param>
        /// <returns></returns>
        /// <remarks>Este método altera um cliente cadastrado na base de dados</remarks>
        [ProducesResponseType(typeof(Scheduling), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<IActionResult> PutSchedules(int id, Scheduling scheduling)
        {
            var scheduleAtualizado = await _scheduling.UpdateSchedulesAsync(scheduling);
            if (scheduleAtualizado == null)
            {
                return NotFound(); //Status Code --> 404	Not Found	O recurso solicitado ou o endpoint não foi encontrado.
            }
            return Ok(); //Status Code --> 200	OK	O recurso solicitado foi processado e retornado com sucesso.
        }


        /// <summary>
        /// Exclui um cliente cadastrado na base.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir um cliente o mesmo será removido permanetemente da basa</remarks>
        [ProducesResponseType(typeof(Scheduling), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            await _scheduling.DeleteScheduleAsync(id);
            return NoContent();
        }
    }
}
