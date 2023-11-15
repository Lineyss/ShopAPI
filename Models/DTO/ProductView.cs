using ShopAPI2.Models.DataBaseModels;

namespace ShopAPI2.Models.ViewModels
{
    public class ProductView
    {
        public ProductView(Product product)
        {
            ID = product.ID;
            Title = product.Title;
            ImagePath = product.ImagePath;
            Description = product.Description;
            Price = product.Price;
            count = product.Count;
            IsExist = product.IsExist;
            Category = product.Category.Title;
        }

        public int ID { get; private set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        private int count;
        public int Count 
        { 
            get
            {
                return count;
            }
            set
            {
                if(value >= 0)
                {
                    count = 0;
                    IsExist = false;
                }
                else
                {
                    count = value;
                    IsExist = true;
                }

            }
        }
        public bool IsExist { get; set; }
        public string Category { get; set; }
    }
}
