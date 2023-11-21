using Microsoft.AspNetCore.Mvc;
using ShopAPI2.Controllers.Help;
using ShopAPI2.Models.DTO;
using ShopAPI2.Services;
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
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
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
        public async Task<ActionResult<ProductDTO>> GetID(int ID)
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
        public async Task<ActionResult<ProductDTO>> GetRequereParam(string Title)
        {
            return await base.GetRequereParam(Title);
        }

        /// <summary>
        /// Создать новый продукт
        /// </summary>
        /// <param name="ProductPOSTDTO"></param>
        /// <response code="201">Новый продукт создан</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductDTO>> Create([FromForm] ProductPOSTDTO ProductPOSTDTO) 
        {
            ProductDTO ProductDTO;
            UploadImage upload = new UploadImage();

            try
            {
                upload.Upload(ProductPOSTDTO.Image);

                ProductDTO = new ProductDTO(ProductPOSTDTO);
                ProductDTO.ImagePath = upload.GetUploadingFile();

                ActionResult<ProductDTO> actionResult = await Create(ProductDTO);

                string typeResult = actionResult.Result.GetType().Name;

                if (typeResult == "OkObjectResult")
                    return actionResult;

                throw new Exception();
            }
            catch
            {
                System.IO.File.Delete(upload.GetUploadingFile());
                return BadRequest(); 
            }

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
        public async Task<ActionResult> Delete(int ID)
        {
            return await base.Delete(ID);
        }

        /// <summary>
        /// Обновить существующий продукт по ID
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Product"></param>
        /// <response code="200">Продукт обновлен</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpPut("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductDTO>> Update(int ID, [FromForm] ProductPOSTDTO Product)
        {
            ProductDTO ProductDTO;
            UploadImage upload = new UploadImage();

            try
            {
                upload.Upload(Product.Image);

                ProductDTO = new ProductDTO(Product);
                ProductDTO.ImagePath = upload.GetUploadingFile();

                var actionResult = await Update(ID, ProductDTO);

                string typeResult = actionResult.Result.GetType().Name;

                if (typeResult == "OkObjectResult")
                    return actionResult;

                throw new Exception();
            }
            catch
            {
                System.IO.File.Delete(upload.GetUploadingFile());
                return BadRequest();
            }

        }

        protected override bool IsValid(ProductDTO model)
        {
            if (
                String.IsNullOrWhiteSpace(model.Title) ||
                String.IsNullOrWhiteSpace(model.Description) ||
                String.IsNullOrWhiteSpace(model.ImagePath)
                )
            {
                return false;
            }

            return true;
        }
    }
}
