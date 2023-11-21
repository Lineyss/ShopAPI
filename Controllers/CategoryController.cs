using Microsoft.AspNetCore.Mvc;
using ShopAPI2.Controllers.Help;
using ShopAPI2.Models.DTO;
using ShopAPI2.Services.DTOServices.Help;

namespace ShopAPI2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : AController<CategoryDTO>
    {
        public CategoryController(IDTOServices<CategoryDTO> iCategory) : base(iCategory)
        {
        }

        /// <summary>
        /// Получить данные о всех категориях
        /// </summary>
        /// <response code="200">Возвращает массив категорий</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            return await base.Get();
        }

        /// <summary>
        /// Получить категорию по ID
        /// </summary>
        /// <response code="200">Возвращает категорию</response>
        /// <response code="400">Не верно переданны данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpGet("{ID:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CategoryDTO>> GetID(int ID)
        {
            return await base.GetID(ID);
        }

        /// <summary>
        /// Создать новую категорию
        /// </summary>
        /// <param name="Title"></param>
        /// <response code="200">Новая категория созданна</response>
        /// <response code="400">Не верно переданны данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpGet("{Title}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CategoryDTO>> GetRequereParam(string Title)
        {
            return await base.GetRequereParam(Title);
        }

        /// <summary>
        /// Создать новую категорию
        /// </summary>
        /// <param name="Title"></param>
        /// <response code="201">Новая категория созданна</response>
        /// <response code="400">Не верно переданны данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<CategoryDTO>> Create([FromForm] string Title)
        {
            return await base.Create(new CategoryDTO(Title));
        }

        /// <summary>
        /// Удалить категорию по ID
        /// </summary>
        /// <param name="ID"></param>
        /// <response code="200">Категория удалена</response>
        /// <response code="400">Не верно переданны данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpDelete]
        [Route("Delete/{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int ID )
        {
            return await base.Delete(ID);
        }

        /// <summary>
        /// Обновить существующую категорию по ID
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Title"></param>
        /// <response code="200">Категория обновлена</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpPut]
        [Route("Update/{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CategoryDTO>> Update(int ID, [FromForm] string Title )
        {
            return await base.Update(ID, new CategoryDTO(Title));
        }

        protected override bool IsValid(CategoryDTO model)
        {
            if (String.IsNullOrWhiteSpace(model.Title))
                return false;

            return true;
        }
    }
}