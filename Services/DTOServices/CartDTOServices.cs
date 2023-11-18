using Microsoft.EntityFrameworkCore;
using ShopAPI2.Models.DataBaseModels;
using ShopAPI2.Models.DTO;
using ShopAPI2.Services.DTOServices.Help;

namespace ShopAPI2.Services.DTOServices
{
    public class CartDTOServices : ICartDOService
    {
        private readonly DataBaseWorker db;
        private readonly List<CartDTO> cartList = new List<CartDTO>();

        public CartDTOServices(DataBaseWorker db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CartDTO>> GetAll()
        {
            foreach(var user in db.users)
            {
                List<ProductDTO> products = db.cart
                    .Where(element => element.IDUser == user.ID)
                    .Include(element => element.Product)
                    .Select(element => new ProductDTO(element.Product))
                    .ToList();

                if(products != null || products.Count() == 0)
                {
                    CartDTO cart = new CartDTO(user.ID, products);
                    cartList.Add(cart);
                }
            }

            return cartList;
        }

        public async Task<CartDTO> GetByUserID(int ID)
        {
            await GetAll();

            return cartList.FirstOrDefault(element=> element.ID == ID)?? new CartDTO(ID, null);
        }

        public async Task<IEnumerable<CartDTO?>> GetByProductID(int ID)
        {
            await GetAll();

            return cartList.Where(element => element.productsList.FirstOrDefault(item=> item.ID == ID) != null);
        }

        public async Task<CartDTO?> GetByUserName(string value)
        {
            await GetAll();

            User? user = await db.users.FirstOrDefaultAsync(element => element.Login == value);

            if (user == null)
                return null;

            return cartList.FirstOrDefault(element => element.ID == user.ID) ?? new CartDTO(user.ID, null);
        }

        public async Task<IEnumerable<CartDTO?>> GetByProductName(string value)
        {
            await GetAll();

            return cartList.Where(element => element.productsList.FirstOrDefault(item => item.Title == value) != null);
        }

        public async Task<CartDTO> Create(int IDProduct, int IDUser)
        {
            CartDTO? cartDTO = await GetByUserID(IDUser);

            if (cartDTO == null)
                return null;

            ProductDTO? productDTO = cartDTO.productsList.FirstOrDefault(element => element.ID == IDProduct);
            
            if(productDTO == null)
            {
                ProductDTOService productDTOService = new ProductDTOService(db);

                productDTO = await productDTOService.GetBy(IDProduct);

                Cart product = new Cart
                {
                    CountProduct = 1,
                    IDProduct = IDProduct,
                    IDUser = IDUser
                };

                db.cart.Add(product);
                db.SaveChanges();
            }
            else
            {
                Update(IDProduct, IDUser, productDTO.Count++);
            }

            return cartDTO;
        }

        public async Task<CartDTO> Delete(int IDUser, int IDProduct)
        {
            Cart? cart = db.cart.FirstOrDefault(element => element.IDUser == IDUser && element.IDProduct == IDProduct);
            if (cart == null)
                return null;

            db.cart.Remove(cart);
            db.SaveChanges();

            return await GetByUserID(IDUser);
        }

        public async Task<CartDTO?> Update(int IDProduct, int IDUser, int Count)
        {
            if (Count < 0)
                return null;

            else if (Count == 0)
                return await Delete(IDUser, IDProduct);

            Cart? cart = await db.cart.FirstOrDefaultAsync(element => element.IDUser == IDUser && element.IDProduct == IDProduct);

            if (cart == null)
                return null;

            cart.CountProduct = Count;
            db.SaveChanges();

            return await GetByUserID(IDUser);
        }
    }
}