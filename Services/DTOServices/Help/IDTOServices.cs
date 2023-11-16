namespace ShopAPI2.Services.DTOServices.Help
{
    public interface IDTOServices<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetBy(int ID);
        Task<T?> GetBy(string value);
        Task<T> Create(T element);
        Task<bool> Delete(int ID);
        Task<T?> Update(int ID, T element);
    }
}
 