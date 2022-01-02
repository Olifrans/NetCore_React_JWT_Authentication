using Microsoft.AspNetCore.Mvc;
using NetCoreReactJwt.BusinessManager.Interfaces;
using NetCoreReactJwt.Domain.Entities;
using NetCoreReactJwt.Domain.Shared.ModelViewsDtos.ClientDtos;

namespace NetCoreReactJwt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserBusinessManager _userManager;

        public AuthController(IUserBusinessManager userManager)
        {
            this._userManager = userManager;
        }


        ///// <summary>
        ///// Cadastra um novo usuario.
        ///// </summary>
        ///// <param name="user"></param>
        ///// <returns></returns>
        ///// <remarks>Este método cadastra um novo usuario na base de dados</remarks>
        //[ProducesResponseType(typeof(User), StatusCodes.Status201Created)]
        //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        //[HttpPost]
        //[Route("users")]
        //public IActionResult Register(User user)
        //{
        //    User userInsert;
        //    userInsert = _userManager.CreateUser(user);
        //    return CreatedAtAction(nameof(CreateUserId), new { id = userInsert.Id }, userInsert); //Status 
        //}

        //// GET api/<AuthController>/5
        //[HttpGet("{id}")]
        //public IActionResult CreateUserId(int id)
        //{
        //    return Ok(id);
        //}







        /// <summary>
        /// Retorna todos os clientes cadastrado na base.
        /// </summary>
        /// <remarks>Este método retorna todos os clientes cadastrados na base de dados</remarks>
        [HttpGet]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userManager.GetUsersAsync());
        }



        /// <summary>
        /// Cadastra um novo cliente.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <remarks>Este método cadastra um novo cliente na base de dados</remarks>
        [ProducesResponseType(typeof(User), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> CreateNewUser(NewUser newUser)
        {
            User userInsert;
            userInsert = await _userManager.InsertUsersAsync(newUser);
            return CreatedAtAction(nameof(GetUsersd), new { id = userInsert.Id }, userInsert); //Status 
        }



        /// <summary>
        /// Retorna apenas um clientes consultado pelo id.
        /// </summary>
        /// <param name="id" example="123"> Id do cliente</param>
        /// <remarks>Este método retorna apenas um clientes da base de dados, consultado pelo id</remarks>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsersd(int id)
        {
            return Ok(await _userManager.GetUsersIdAsync(id));
        }




        /// <summary>
        /// Altera um cliente cadastrado.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <remarks>Este método altera um cliente cadastrado na base de dados</remarks>
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUser userUpdate)
        {            
            var updatedUser = await _userManager.UpdateUsersAsync(userUpdate);
            if (updatedUser == null)
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
        [ProducesResponseType(typeof(User), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userManager.DeleteUsersAsync(id);
            return NoContent();
        }
    }
}
