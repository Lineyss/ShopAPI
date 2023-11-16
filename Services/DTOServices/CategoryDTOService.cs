using Microsoft.EntityFrameworkCore;
using ShopAPI2.Models.DataBaseModels;
using ShopAPI2.Models.DTO;
using ShopAPI2.Services.DTOServices.Help;
using System.Xml.Linq;

namespace ShopAPI2.Services.DTOServices
{
    public class CategoryDTOService : IDTOServices<CategoryDTO>
    {
        private readonly DataBaseWorker db;
        public CategoryDTOService(DataBaseWorker db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            return await db.category.Select(element => new CategoryDTO(element)).ToListAsync();
        }

        public async Task<CategoryDTO?> GetBy(int ID)
        {
            Category? category = await db.category.FirstOrDefaultAsync(element => element.ID == ID);
            
            return category == null? null: new CategoryDTO(category);
        }

        public async Task<CategoryDTO?> GetBy(string value)
        {
            if (value == null)
                return null;

            Category? category = await db.category.FirstOrDefaultAsync(element => element.Title == value);

            return category == null ? null : new CategoryDTO(category);
        }

        public async Task<CategoryDTO> Create(CategoryDTO element)
        {
            if (element == null)
                return null;

            Category? category = await db.category.FirstOrDefaultAsync(item => item.Title == element.Title);
            
            if (category != null)
                return null;

            category = new Category();

            category.Title = element.Title;

            db.category.Add(category);
            db.SaveChanges();

            return new CategoryDTO(category);
        }

        public async Task<bool> Delete(int ID)
        {
            Category? category = await db.category.FirstOrDefaultAsync(element => element.ID == ID);
            if (category == null)
                return false;

            db.category.Remove(category);
            db.SaveChanges();

            return true;
        }

        public async Task<CategoryDTO?> Update(int ID, CategoryDTO element)
        {
            if (element == null)
                return null;

            Category? category = await db.category.FirstOrDefaultAsync(item => item.ID == ID);

            if (category == null)
                return null;

            category.Title = element.Title;

            db.SaveChanges();

            return new CategoryDTO(category);
        }
    }
}
