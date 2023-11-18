using Microsoft.EntityFrameworkCore;
using ShopAPI2.Models.DataBaseModels;
using ShopAPI2.Models.DTO;
using ShopAPI2.Services.DTOServices.Help;

namespace ShopAPI2.Services.DTOServices
{
    public class ProductDTOService : IDTOServices<ProductDTO>
    {
        private readonly DataBaseWorker db;
        public ProductDTOService(DataBaseWorker db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllIsExist()
        {
            return await db.products.Where(element=> element.IsExist).Include(element => element.Category).Select(element => new ProductDTO(element)).ToListAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            return await db.products.Include(element => element.Category).Select(element => new ProductDTO(element)).ToListAsync();
        }

        public async Task<ProductDTO?> GetBy(int ID)
        {
            Product? product = await db.products.Include(element => element.Category).FirstOrDefaultAsync(element => element.ID == ID);
            if (product == null)
                return null;

            return new ProductDTO(product);
        }

        public async Task<ProductDTO?> GetBy(string value)
        {
            Product? product = await db.products.Include(element => element.Category).FirstOrDefaultAsync(element => element.Title == value);
            if (product == null)
                return null;

            return new ProductDTO(product);
        }

        public async Task<ProductDTO> Create(ProductDTO element)
        {
            if (element == null)
                return null;

            Product? product = await db.products.FirstOrDefaultAsync(item => item.Title == element.Title);
            Category? category = await db.category.FirstOrDefaultAsync(item => item.ID == element.GetIDCategory());

            if (product != null || category == null)
                return null;

            product = new Product();

            product.Title = element.Title;
            product.Price = element.Price;
            product.ImagePath = element.ImagePath;
            product.Count = element.Count;
            product.Description = element.Description;
            product.IDCategory = category.ID;
            product.Category = category;

            db.products.Add(product);
            db.SaveChanges();

            return new ProductDTO(product);
        }

        public async Task<bool> Delete(int ID)
        {
            Product? product = await db.products.FirstOrDefaultAsync(element => element.ID == ID);
            if (product == null)
                return false;

            File.Delete(product.ImagePath);

            db.products.Remove(product);
            db.SaveChanges();

            return true;
        }

        public async Task<ProductDTO?> Update(int ID, ProductDTO element)
        {
            if (element == null)
                return null;

            Product? product = await db.products.FirstOrDefaultAsync(item => item.ID == ID);
            Category? category = await db.category.FirstOrDefaultAsync(item => item.ID == element.GetIDCategory());

            if (product == null || category == null)
                return null;

            if (product.ImagePath != element.ImagePath)
                File.Delete(product.ImagePath);

            product.Title = element.Title;
            product.Price = element.Price;
            product.ImagePath = element.ImagePath;
            product.Count = element.Count;
            product.Description = element.Description;
            product.IDCategory = category.ID;
            product.Category = category;

            db.SaveChanges();

            return new ProductDTO(product);
        }
    }
}
