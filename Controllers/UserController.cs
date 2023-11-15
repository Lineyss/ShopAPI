using Microsoft.AspNetCore.Mvc;
using ShopAPI2.Controllers.Help;
using ShopAPI2.Models.DTO;
using ShopAPI2.Services.DTOServices.Help;

namespace ShopAPI2.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase, IController<UserDTO>
    {
        private readonly IDTOServices<UserDTO> iUser;
        public UserController(IDTOServices<UserDTO> iUser)
        {
            this.iUser = iUser;
        }

        /// <summary>
        /// Получить данные о всех пользователях
        /// </summary>
        /// <response code="200">Возвращает массив пользователей</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
        {
            try
            {
                return Ok(await iUser.GetAll());
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Получить пользователя по ID
        /// </summary>
        /// <param name="ID"></param>
        /// <response code="200">Пользователь передан</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpGet("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDTO>> GetID(int ID)
        {
            try
            {
                UserDTO? user = await iUser.GetBy(ID);

                if (user == null)
                    return BadRequest();


                return Ok(user);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Получить пользователя по Логину
        /// </summary>
        /// <param name="login"></param>
        /// <response code="200">Пользователь передан</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpGet("{login}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDTO>> GetLogin(string login)
        {
            try
            {
                UserDTO? user = await iUser.GetBy(login);

                if (user == null)
                    return BadRequest();

                return Ok(user);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Создать нового пользователя
        /// </summary>
        /// <param name="element"></param>
        /// <response code="200">Пользователь создан</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDTO>> Create([FromBody] UserDTO element)
        {
            try
            {
                UserDTO? user = await iUser.Create(element);

                if (user == null)
                    return BadRequest();

                return Ok(user);
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Удалить пользователя по ID
        /// </summary>
        /// <param name="ID"></param>
        /// <response code="200">Пользователь удален</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpDelete("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int ID)
        {
            try
            {
                bool user = await iUser.Delete(ID);

                if (user == false)
                    return BadRequest();

                return Ok(user);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Обновить существующего пользователя по ID
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="element"></param>
        /// <response code="200">Пользователь обновлен</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpPut("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDTO>> Update(int ID, [FromBody] UserDTO element)
        {
            try
            {
                UserDTO? user = await iUser.Update(ID, element);

                if (user == null)
                    return BadRequest();

                return Ok(user);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
