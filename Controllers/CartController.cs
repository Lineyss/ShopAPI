using Microsoft.AspNetCore.Mvc;
using ShopAPI2.Controllers.Help;
using ShopAPI2.Models.DTO;
using ShopAPI2.Services.DTOServices;
using ShopAPI2.Services.DTOServices.Help;

namespace ShopAPI2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartDOService iService;
        public CartController(ICartDOService iService)
        {
            this.iService = iService;
        }

        /// <summary>
        /// Получить данные о всех карзинах
        /// </summary>
        /// <response code="200">Возвращает массив ролей</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CartDTO>>> GetALL()
        {
            try
            {
                return Ok(await iService.GetAll());
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
