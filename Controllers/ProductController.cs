using Microsoft.AspNetCore.Mvc;
using ShopAPI2.Controllers.Help;
using ShopAPI2.Models.DTO;
using ShopAPI2.Services.DTOServices.Help;

namespace ShopAPI2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : AController<ProductDTO>
    {
        public ProductController(IDTOServices<ProductDTO> iService) : base(iService)
        {
        }

        /// <summary>
        /// Получить данные о всех продуктах
        /// </summary>
        /// <response code="200">Продукты переданы</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async override Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            return await base.Get();
        }

        /// <summary>
        /// Получить продукт по ID
        /// </summary>
        /// <param name="ID"></param>
        /// <response code="200">Продукт передан</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpGet("{ID:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async override Task<ActionResult<ProductDTO>> GetID(int ID)
        {
            return await base.GetID(ID);
        }

        /// <summary>
        /// Получить продукт по названию
        /// </summary>
        /// <param name="Title"></param>
        /// <response code="200">Продукт передан</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpGet("{Title}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async override Task<ActionResult<ProductDTO>> GetRequereParam(string Title)
        {
            return await base.GetRequereParam(Title);
        }

        /// <summary>
        /// Создать новый продукт
        /// </summary>
        /// <param name="model"></param>
        /// <response code="200">Новый продукт создан</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async override Task<ActionResult<ProductDTO>> Create([FromBody] ProductDTO model)
        {
            return await base.Create(model);
        }

        /// <summary>
        /// Удалить продукт по ID
        /// </summary>
        /// <param name="ID"></param>
        /// <response code="200">Продукт удален</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpDelete("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async override Task<ActionResult> Delete(int ID)
        {
            return await base.Delete(ID);
        }

        /// <summary>
        /// Обновить существующий продукт по ID
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="model"></param>
        /// <response code="200">Продукт обновлен</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpPut("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async override Task<ActionResult<ProductDTO>> Update(int ID, [FromBody] ProductDTO model)
        {
            return await base.Update(ID, model);
        }

        protected override bool IsValid(ProductDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
