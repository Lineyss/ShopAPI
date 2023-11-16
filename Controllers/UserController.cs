using Microsoft.AspNetCore.Mvc;
using ShopAPI2.Controllers.Help;
using ShopAPI2.Models.DTO;
using ShopAPI2.Services.DTOServices;
using ShopAPI2.Services.DTOServices.Help;

namespace ShopAPI2.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : AController<UserDTO>
    {
        private readonly CartDTOServices sCart;
        public UserController(IDTOServices<UserDTO> iUser, CartDTOServices sCart) : base(iUser)
        {
            this.sCart = sCart;
        }

        /// <summary>
        /// Получить данные о всех пользователях
        /// </summary>
        /// <response code="200">Возвращает массив пользователей</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async override Task<ActionResult<IEnumerable<UserDTO>>> Get()
        {
            return await base.Get();
        }

        /// <summary>
        /// Получить пользователя по ID
        /// </summary>
        /// <param name="ID"></param>
        /// <response code="200">Пользователь передан</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpGet("{ID:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async override Task<ActionResult<UserDTO>> GetID(int ID)
        {
            return await base.GetID(ID);
        }

        /// <summary>
        /// Получить пользователя по логину
        /// </summary>
        /// <param name="login"></param>
        /// <response code="200">Пользователь передан</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpGet]
        [Route("{Login}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async override Task<ActionResult<UserDTO>> GetRequereParam(string login)
        {
            return await base.GetRequereParam(login);
        }

        /// <summary>
        /// Получить карзину пользователя по ID
        /// </summary>
        /// <param name="ID"></param>
        /// <response code="200">Пользователь создан</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpGet]
        [Route("{ID:int}/Cart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CartDTO>> GetCart(int ID)
        {
            try
            {
                CartDTO? cart = await sCart.GetByUserID(ID);
                if (cart == null)
                    return BadRequest();

                return cart;
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Получить карзину пользователя по логину
        /// </summary>
        /// <param name="Login"></param>
        /// <response code="200">Пользователь создан</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpGet]
        [Route("{Login}/Cart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CartDTO>> GetCart(string Login)
        {
            try
            {
                CartDTO? cart = await sCart.GetByUserName(Login);
                if (cart == null)
                    return BadRequest();

                return cart;
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Создать нового пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <response code="200">Пользователь создан</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async override Task<ActionResult<UserDTO>> Create([FromBody] UserDTO model)
        {
            return await base.Create(model);
        }

        /// <summary>
        /// Добавить товар в карзину по ID товара и пользователя
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="IDProduct"></param>
        /// <response code="200">Пользователь удален</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpPost]
        [Route("{ID:int}/Cart/{IDProduct:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CartDTO>> AddProduct(int ID, int IDProduct)
        {
            try
            {
                CartDTO? cart = await sCart.Create(IDProduct, ID);
                if (cart == null)
                    return BadRequest();

                return null;
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Добавить товар в карзину по ID товара и логину пользователя
        /// </summary>
        /// <param name="Login"></param>
        /// <param name="IDProduct"></param>
        /// <response code="200">Пользователь удален</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpPost]
        [Route("{Login}/Cart/{IDProduct:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CartDTO>> AddProduct(string Login, int IDProduct)
        {
            try
            {
                int ID = GetRequereParam(Login).Id;

                CartDTO? cart = await sCart.Create(IDProduct, ID);
                if (cart == null)
                    return BadRequest();

                return null;
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Удалить пользователя по ID товара и пользователя
        /// </summary>
        /// <param name="ID"></param>
        /// <response code="200">Пользователь удален</response>
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
        /// Удалить товар из карзины по ID
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="IDProduct"></param>
        /// <response code="200">Пользователь удален</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpDelete]
        [Route("{ID:int}/Cart/{IDProduct:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CartDTO>> DeleteProduct(int ID, int IDProduct)
        {
            try
            {
                CartDTO? cart = await sCart.Delete(ID,IDProduct);
                if (cart == null)
                    return BadRequest();

                return Ok(cart);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Удалить товар из карзины по ID товара и логину пользователя
        /// </summary>
        /// <param name="Login"></param>
        /// <param name="IDProduct"></param>
        /// <response code="200">Пользователь удален</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpDelete]
        [Route("{Login}/Cart/{IDProduct:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CartDTO>> DeleteProduct(string Login, int IDProduct)
        {
            try
            {
                int ID = GetRequereParam(Login).Id;

                CartDTO? cart = await sCart.Delete(ID, IDProduct);
                if (cart == null)
                    return BadRequest();

                return Ok(cart);
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
        /// <param name="model"></param>
        /// <response code="200">Пользователь обновлен</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpPut("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async override Task<ActionResult<UserDTO>> Update(int ID, [FromBody] UserDTO model)
        {
            return await base.Update(ID, model);
        }

        /// <summary>
        /// Обновать товар в карзине по ID товара и пользователя
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="IDProduct"></param>
        /// <response code="200">Пользователь удален</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpPut]
        [Route("{ID:int}/Cart/{IDProduct:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CartDTO>> UpdateCountProduct(int ID, int IDProduct, int Count)
        {
            try
            {
                CartDTO? cart = await sCart.Update(ID, IDProduct, Count);

                if (cart == null)
                    return BadRequest();

                return Ok(cart);
            }
            catch
            {
                return StatusCode(500);
            }
        }


        /// <summary>
        /// Обновать товар в карзине по ID товара и логину пользователя
        /// </summary>
        /// <param name="Login"></param>
        /// <param name="IDProduct"></param>
        /// <response code="200">Пользователь удален</response>
        /// <response code="400">Не верно переданы данные</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        [HttpPut]
        [Route("{Login}/Cart/{IDProduct:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CartDTO>> UpdateCountProduct(string Login, int IDProduct, int Count)
        {
            try
            {
                int ID = GetRequereParam(Login).Id;

                CartDTO? cart = await sCart.Update(ID, IDProduct, Count);

                if (cart == null)
                    return BadRequest();

                return Ok(cart);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        protected override bool IsValid(UserDTO model)
        {
            if(
                String.IsNullOrWhiteSpace(model.Login) ||
                String.IsNullOrWhiteSpace(model.Password) ||
                String.IsNullOrWhiteSpace(model.SecondName) ||
                String.IsNullOrWhiteSpace(model.FirstName) ||
                String.IsNullOrWhiteSpace(model.MidleName) ||
                String.IsNullOrWhiteSpace(model.Email) ||
                String.IsNullOrWhiteSpace(model.Phone) ||
                String.IsNullOrWhiteSpace(model.Role)
                )
            {
                return false;
            }

            return true;
        }
    }
}
