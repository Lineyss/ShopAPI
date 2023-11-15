using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopAPI2.Controllers.Help;
using ShopAPI2.Models.DataBaseModels;
using ShopAPI2.Models.DTO;

namespace ShopAPI2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase, IController<RoleViewModel>
    {
        private readonly DataBaseWorker db;
        public RoleController(DataBaseWorker db)
        {
            this.db = db;
        }

        /// <summary>
        /// Получить данные о всех ролях
        /// </summary>
        /// <response code="200">Возвращает массив ролей</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<RoleViewModel>> Get()
        {
            try
            {
                return Ok(RoleViewModel.Builder(db.roles));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Получить роль по ID
        /// </summary>
        /// <response code="200">Возвращает элемент по ID</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpGet("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<RoleViewModel> GetID(int ID)
        {
            try
            {
                Role? role = db.roles.FirstOrDefault(element => element.ID == ID);
                if (role == null)
                    return BadRequest();

                return Ok(new RoleViewModel(role));
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
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<RoleViewModel> Create([FromBody] RoleViewModel element)
        {
            try
            {
                if (element == null)
                    return BadRequest();

                Role role = db.roles.FirstOrDefault(item => element.Title == item.Title);

                if (role != null)
                    return BadRequest();

                db.roles.Add(element.Create());
                db.SaveChanges();

                return Ok(RoleViewModel.Builder(db.roles).First(element => element.ID == element.ID));
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
        [HttpDelete]
        [Route("Delete/{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(int ID)
        {
            try
            {
                Role? role = db.roles.FirstOrDefault(element => element.ID == ID);
                if (role == null)
                    return BadRequest();

                db.roles.Remove(role);
                db.SaveChanges();
                return Ok();
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
        [HttpPut]
        [Route("Update/{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<RoleViewModel> Update(int ID, [FromBody] RoleViewModel element)
        {
            try
            {
                Role? role = db.roles.FirstOrDefault(element => element.ID == element.ID);
                if (role == null)
                    return BadRequest();

                db.Entry(role).CurrentValues.SetValues(element.Update(ID));
                db.SaveChanges();

                return Ok(new RoleViewModel(db.roles.First(element => element.ID == element.ID)));
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
