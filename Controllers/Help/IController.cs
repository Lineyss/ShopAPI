using Microsoft.AspNetCore.Mvc;

namespace ShopAPI2.Controllers.Help
{
    public interface IController <T>
    {
        ActionResult<IEnumerable<T>> Get();
        ActionResult<T> GetID(int ID);
        ActionResult<T> Create([FromBody] T element);

        ActionResult Delete(int ID);
        ActionResult<T> Update(int ID, [FromBody] T element);
    }
}
