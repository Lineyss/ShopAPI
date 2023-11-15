﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopAPI2.Controllers.Help;
using ShopAPI2.Models.DTO;
using ShopAPI2.Services.DTOServices.Help;

namespace ShopAPI2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase, IController<RoleDTO>
    {
        private readonly IDTOServices<RoleDTO> iRole;
        public RoleController(IDTOServices<RoleDTO> iRole)
        {
            this.iRole = iRole;
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
            try
            {
                return Ok(await iRole.GetAll());
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Получить роль по ID
        /// </summary>
        /// <param name="ID"></param>
        /// <response code="200">Возвращает элемент по ID</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpGet("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RoleDTO>> GetID(int ID)
        {
            try
            {
                RoleDTO? role = await iRole.GetBy(ID);
                if (role == null)
                    return BadRequest();

                return Ok(role);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Получить роль по названию
        /// </summaryTitle
        /// <param name="Title"></param>
        /// <response code="200">Возвращает элемент по ID</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpGet("{Title}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RoleDTO>> GetID(string Title)
        {
            try
            {
                RoleDTO? role = await iRole.GetBy(Title);
                if (role == null)
                    return BadRequest();

                return Ok(role);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Создать новую роли
        /// </summary>
        /// <param name="element"></param>
        /// <response code="200">Новая роль создана</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RoleDTO>> Create([FromBody] RoleDTO element)
        {
            try
            {
                if (element == null)
                    return BadRequest();

                RoleDTO? role = await iRole.Create(element);

                if (role == null)
                    return BadRequest();

                return Ok(role);
            }
            catch
            {
                return StatusCode(500);
            }
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
        public async Task<ActionResult> Delete(int ID)
        {
            try
            {
                bool valid = await iRole.Delete(ID);

                if(valid)
                    return Ok();

                return BadRequest();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Обновить существующую роль по ID
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="element"></param>
        /// <response code="200">Элемент удален из базы данных</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpPut("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RoleDTO>> Update(int ID, [FromBody] RoleDTO element)
        {
            try
            {
                RoleDTO? role = await iRole.Update(ID, element);

                if (role == null)
                    return BadRequest();

                return Ok(role);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
