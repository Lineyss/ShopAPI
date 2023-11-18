using ShopAPI2.Models.DataBaseModels;
using System.ComponentModel.DataAnnotations;

namespace ShopAPI2.Models.DTO
{
    public class CategoryDTO
    {
        public CategoryDTO()
        {

        }

        public CategoryDTO(Category category)
        {
            ID = category.ID;
            Title = category.Title;
        }

        public CategoryDTO(string Title)
        {
            ID = 0;
            this.Title = Title;
        }

        public int ID { get; private set; }
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
    }
}
