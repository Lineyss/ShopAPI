using ShopAPI2.Models.DataBaseModels;

namespace ShopAPI2.Models.ViewModels
{
    public class CategoryView
    {
        public CategoryView(Category category)
        {
            ID = category.ID;
            Title = category.Title;
        }
        
        public int ID { get; private set; }
        public string Title { get; set; }
    }
}
