using Microsoft.AspNetCore.Mvc;
using NetCoreReactJwt.BusinessManager.Interfaces;
using NetCoreReactJwt.Domain.Clientcs;


namespace NetCoreReactJwt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClienteBusinessManager _cliente;
        public ClientController(IClienteBusinessManager cliente)
        {
            _cliente = cliente;
        }



        /// <summary>
        /// Retorna todos os clientes cadastrado na base.
        /// </summary>
        /// <remarks>Este método retorna todos os clientes cadastrados na base de dados</remarks>
        [HttpGet]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetClients()
        {
            return Ok(await _cliente.GetClientsAsync());
        }


        /// <summary>
        /// Retorna apenas um clientes consultado pelo id.
        /// </summary>
        /// <param name="id" example="123"> Id do cliente</param>
        /// <remarks>Este método retorna apenas um clientes da base de dados, consultado pelo id</remarks>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetClientId(int id)
        {
            return Ok(await _cliente.GetClientsIdAsync(id));
        }



        /// <summary>
        /// Cadastra um novo cliente.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        /// <remarks>Este método cadastra um novo cliente na base de dados</remarks>
        [ProducesResponseType(typeof(Client), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> PostClients(Client cliente)
        {
            Client clienteInserido;
            clienteInserido = await _cliente.InsertClientsAsync(cliente);
            return CreatedAtAction(nameof(GetClientId), new { id = clienteInserido.Id }, clienteInserido); //Status 
        }


        /// <summary>
        /// Altera um cliente cadastrado.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        /// <remarks>Este método altera um cliente cadastrado na base de dados</remarks>
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<IActionResult> Putcliente(int id, Client cliente)
        {
            var clienteAtualizado = await _cliente.UpdateClientsAsync(cliente);
            if (clienteAtualizado == null)
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
        [ProducesResponseType(typeof(Client), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _cliente.DeleteClientsAsync(id);
            return NoContent();
        }
    }
}
