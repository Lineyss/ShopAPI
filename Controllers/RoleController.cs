using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopAPI2.Controllers.Help;
using ShopAPI2.Models.DTO;
using ShopAPI2.Services.DTOServices.Help;

namespace ShopAPI2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : AController<RoleDTO>
    {
        public RoleController(IDTOServices<RoleDTO> iRole) : base(iRole)
        {

        }

        /// <summary>
        /// Получить данные о всех ролях
        /// </summary>
        /// <response code="200">Возвращает массив ролей</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> Get()
        {
            return await base.Get();
        }

        /// <summary>
        /// Получить роль по ID
        /// </summary>
        /// <param name="ID"></param>
        /// <response code="200">Возвращает элемент по ID</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpGet("{ID:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RoleDTO>> GetID(int ID)
        {
            return await base.GetID(ID);
        }

        /// <summary>
        /// Получить роль по названию
        /// </summary>
        /// <param name="Title"></param>
        /// <response code="200">Возвращает элемент по ID</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpGet("{Title}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RoleDTO>> GetRequereParam(string Title)
        {
            return await base.GetRequereParam(Title);
        }

        /// <summary>
        /// Создать новую роли
        /// </summary>
        /// <param name="Title"></param>
        /// <response code="201">Новая роль создана</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RoleDTO>> Create([FromForm] string Title)
        {
            return await base.Create(new RoleDTO(Title));
        }

        /// <summary>
        /// Удалить роли по ID
        /// </summary>
        /// <param name="ID"></param>
        /// <response code="200">Элемент удален из базы данных</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpDelete("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int ID )
        {
            return await base.Delete(ID);
        }

        /// <summary>
        /// Обновить существующую роль по ID
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Title"></param>
        /// <response code="200">Элемент удален из базы данных</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpPut("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RoleDTO>> Update(int ID, [FromForm] string Title)
        {
            return await base.Update(ID, new RoleDTO(Title));
        }

        protected override bool IsValid(RoleDTO model)
        {
            if (String.IsNullOrWhiteSpace(model.Title))
                return false;

            return true;
        }
    }
}
