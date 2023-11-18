using ShopAPI2.Models.DTO;

namespace ShopAPI2.Services.DTOServices.Help
{
    public interface ICartDOService
    {
        Task<IEnumerable<CartDTO>> GetAll();
        Task<CartDTO> GetByUserID(int ID);
        Task<IEnumerable<CartDTO?>> GetByProductID(int ID);
        Task<CartDTO?> GetByUserName(string value);
        Task<IEnumerable<CartDTO?>> GetByProductName(string value);
        Task<CartDTO> Create(int IDProduct, int IDUser);
        Task<CartDTO> Delete(int IDUser, int IDProduct);
        Task<CartDTO?> Update(int IDProduct, int IDUser, int Count);
    }
}
