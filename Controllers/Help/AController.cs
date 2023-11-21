using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using ShopAPI2.Models.DTO;
using ShopAPI2.Services.DTOServices.Help;
using System.Reflection;
using System.Xml.Linq;

namespace ShopAPI2.Controllers.Help
{

    public abstract class AController<T> : ControllerBase
        where T : class
    {
        private readonly IDTOServices<T> iService;

        public AController(IDTOServices<T> iService)
        {
            this.iService = iService;
        }

        [NonAction]
        protected async Task<ActionResult<IEnumerable<T>>> Get()
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

        [NonAction]
        protected async Task<ActionResult<T>> GetID(int ID)
        {
            try
            {
                T? model = await iService.GetBy(ID);
                if (model == null)
                    return null;

                return Ok(model);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [NonAction]
        protected async Task<ActionResult<T>> GetRequereParam(string Value)
        {
            try
            {
                T? model = await iService.GetBy(Value);
                if (model == null)
                    return null;

                return Ok(model);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [NonAction]
        protected async Task<ActionResult<T>> Create([FromBody] T model)
        {
            try
            {

                if (model == null || !IsValid(model))
                    return BadRequest();

                model = await iService.Create(model);
                
                if (model == null)
                    return BadRequest();

                return Created(HttpContext.Request.GetDisplayUrl() + $"/{GetValueParam<int>(model, "ID")}", model);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [NonAction]
        protected async Task<ActionResult> Delete(int ID)
        {
            try
            {
                bool valid = await iService.Delete(ID);

                if (valid)
                    return Ok();

                return BadRequest();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [NonAction]
        protected async Task<ActionResult<T>> Update(int ID, [FromBody] T model)
        {
            try
            {
                if (!IsValid(model))
                    return BadRequest();

                T? role = await iService.Update(ID, model);

                if (role == null)
                    return BadRequest();

                return Ok(role);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        protected abstract bool IsValid(T model);

        private value GetValueParam<value>(T model, string paramName)
        {
            var param = model.GetType().GetMember(paramName)[0];

            switch (param.MemberType)
            {
                case MemberTypes.Property:
                    // Получение значения
                    return (value)((PropertyInfo)param).GetValue(model);
            }

            throw new Exception();
        }
    }
}
