using Microsoft.AspNetCore.Mvc;

namespace ShopAPI2.Controllers.Help
{
    public interface IController <T>
    {
        Task<ActionResult<IEnumerable<T>>> Get();
        Task<ActionResult<T>> GetID(int ID);
        Task<ActionResult<T>> Create([FromBody] T element);

        Task<ActionResult> Delete(int ID);
        Task<ActionResult<T>> Update(int ID, [FromBody] T element);
    }
}
